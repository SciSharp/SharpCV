using NumSharp;
using NumSharp.Backends;
using NumSharp.Backends.Unmanaged;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    public partial class Mat : DisposableObject
    {
        NDArray _nd;
        public NDArray data
        {
            get
            {
                if (_nd is null)
                    _nd = GetData();

                return _nd;
            }
        }

        int _ndim;
        public int ndim
        {
            get
            {
                cv2_native_api.core_Mat_dims(_handle, out _ndim);
                return _ndim;
            }
        }

        public NPTypeCode dtype { get; set; } = NPTypeCode.Byte;

        MatType _matType = MatType.Unknown;
        public MatType MatType
        {
            get
            {
                if (_matType != MatType.Unknown)
                    return _matType;

                cv2_native_api.core_Mat_type(_handle, out _matType);
                return _matType;
            }
        }

        int[] _dims;
        Shape _shape;
        /// <summary>
        /// HWC
        /// height * width * channel
        /// </summary>
        public Shape shape
        {
            get
            {
                if(_dims != null)
                    return _shape;

                _dims = new int[ndim + (Channels > 1 ? 1 : 0)];
                for (int i = 0; i < ndim; i++)
                    cv2_native_api.core_Mat_sizeAt(_handle, i, out _dims[i]);

                if(Channels > 1)
                    _dims[ndim] = Channels;

                _shape = new Shape(_dims);
                return _shape;
            }
        }

        public int size => shape.Size;

        IntPtr _intputArray;
        public IntPtr InputArray
        {
            get
            {
                if(_intputArray == IntPtr.Zero)
                    cv2_native_api.core_InputArray_new_byMat(_handle, out _intputArray);
                return _intputArray;
            }
        }

        IntPtr _outputArray;
        public IntPtr OutputArray
        {
            get
            {
                if(_outputArray == IntPtr.Zero)
                    cv2_native_api.core_OutputArray_new_byMat(_handle, out _outputArray);
                return _outputArray;
            }
        }

        int _channels = -1;
        public int Channels
        {
            get
            {
                if (_channels > -1)
                    return _channels;

                cv2_native_api.core_Mat_channels(_handle, out _channels);
                return _channels;
            }
        }

        public Mat()
        {
            cv2_native_api.core_Mat_new1(out _handle);
        }

        public Mat(IntPtr handle)
        {
            _handle = handle;
        }

        public unsafe Mat(NDArray nd)
        {
            switch (nd.ndim)
            {
                case 2:
                    cv2_native_api.core_Mat_new8(nd.shape[0], nd.shape[1], FromType(nd.dtype), new IntPtr(nd.Unsafe.Address), new IntPtr(0), out _handle);
                    break;
                default:
                    throw new NotImplementedException("Not supported");
            }
        }

        public unsafe NDArray GetData()
        {
            // we pass donothing as it keeps reference to src preventing its disposal by GC
            switch (MatType)
            {
                case MatType.CV_32SC2:
                    {
                        cv2_native_api.core_Mat_data(_handle, out int* dataPtr);
                        var block = new UnmanagedMemoryBlock<int>(dataPtr, shape.Size, () => DoNothing(_handle));
                        var storage = new UnmanagedStorage(new ArraySlice<int>(block), shape);
                        dtype = NPTypeCode.Int32;
                        return new NDArray(storage);
                    }
                case MatType.CV_32FC1:
                    {
                        cv2_native_api.core_Mat_data(_handle, out float* dataPtr);
                        var block = new UnmanagedMemoryBlock<float>(dataPtr, shape.Size, () => DoNothing(_handle));
                        var storage = new UnmanagedStorage(new ArraySlice<float>(block), shape);
                        dtype = NPTypeCode.Float;
                        return new NDArray(storage);
                    }
                case MatType.CV_8UC1:
                case MatType.CV_8UC3:
                    {
                        cv2_native_api.core_Mat_data(_handle, out byte* dataPtr);
                        var block = new UnmanagedMemoryBlock<byte>(dataPtr, size, () => DoNothing(_handle));
                        var storage = new UnmanagedStorage(new ArraySlice<byte>(block), shape);
                        dtype = NPTypeCode.Byte;
                        return new NDArray(storage);
                    }
                default:
                    throw new NotImplementedException($"Can't find type: {_matType}");
            }
        }

        //this method copies Mat to a new NDArray
        private unsafe NDArray CopyToNDArray()
        {
            cv2_native_api.core_Mat_cols(_handle, out var width);
            cv2_native_api.core_Mat_rows(_handle, out var height);
            cv2_native_api.core_Mat_data(_handle, out byte* data);

            /*var nd = new NDArray(NPTypeCode.Byte, (1, height, width, type), fillZeros: false);
            new UnmanagedMemoryBlock<byte>(data, nd.size)
                .CopyTo(nd.Unsafe.Address);

            return nd;*/
            return new NDArray(NPTypeCode.Byte);
        }

        //this method wraps without copying Mat.
        private unsafe NDArray WrapWithNDArray()
        {
            cv2_native_api.core_Mat_cols(_handle, out var width);
            cv2_native_api.core_Mat_rows(_handle, out var height);
            cv2_native_api.core_Mat_channels(_handle, out var channels);

            Shape shape = (height, width, channels);

            // we pass donothing as it keeps reference to src preventing its disposal by GC
            switch (dtype)
            {
                case NPTypeCode.Single:
                    {
                        cv2_native_api.core_Mat_data(_handle, out float* dataPtr);
                        var block = new UnmanagedMemoryBlock<float>(dataPtr, shape.Size, () => DoNothing(_handle));
                        var storage = new UnmanagedStorage(new ArraySlice<float>(block), shape);
                        return new NDArray(storage);
                    }
                default:
                    {
                        cv2_native_api.core_Mat_data(_handle, out byte* dataPtr);
                        var block = new UnmanagedMemoryBlock<byte>(dataPtr, shape.Size, () => DoNothing(_handle));
                        var storage = new UnmanagedStorage(new ArraySlice<byte>(block), shape);
                        return new NDArray(storage);
                    }
            }
        }

        [MethodImpl(MethodImplOptions.NoOptimization)]
        private void DoNothing(IntPtr ptr)
        {
            var p = ptr;
        }

        public NDArray astype(Type type)
            => data.astype(type);

        protected override void FreeHandle()
        {
            cv2_native_api.core_Mat_delete(_handle);
        }

        public static implicit operator IntPtr(Mat mat)
            => mat._handle;

        public static implicit operator Mat(IntPtr handle)
            => new Mat(handle);

        public static implicit operator NDArray(Mat mat)
            => mat.data;

        public override string ToString()
        {
            return $"{shape.ToString()} {MatType}";
        }

        public MatType FromType(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Single:
                    return MatType.CV_32FC1;
                default:
                    return MatType.CV_8UC1;
            }
        }
    }
}
