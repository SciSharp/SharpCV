using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Tensorflow;
using Tensorflow.NumPy;

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
                return _ndim + (Channels > 1 ? 1 : 0);
            }
        }

        public TF_DataType dtype { get; set; } = np.@byte;

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

                _dims = new int[ndim];
                cv2_native_api.core_Mat_dims(_handle, out _ndim);
                
                for (int i = 0; i < _ndim; i++)
                    cv2_native_api.core_Mat_sizeAt(_handle, i, out _dims[i]);

                if(Channels > 1)
                    _dims[_ndim] = Channels;

                _shape = new Shape(_dims);
                return _shape;
            }
        }

        public long size => shape.size;

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

        public unsafe NDArray GetData()
        {
            // we pass donothing as it keeps reference to src preventing its disposal by GC
            switch (MatType)
            {
                case MatType.CV_32SC1:
                case MatType.CV_32SC2:
                    {
                        cv2_native_api.core_Mat_data(_handle, out int* dataPtr);
                        dtype = TF_DataType.TF_INT32;
                        return new NDArray(new IntPtr(dataPtr), shape, dtype);
                    }
                case MatType.CV_32FC1:
                    {
                        cv2_native_api.core_Mat_data(_handle, out float* dataPtr);
                        dtype = TF_DataType.TF_FLOAT;
                        return new NDArray(new IntPtr(dataPtr), shape, dtype);
                    }
                case MatType.CV_8UC1:
                case MatType.CV_8UC3:
                    {
                        cv2_native_api.core_Mat_data(_handle, out byte* dataPtr);
                        dtype = TF_DataType.TF_UINT8;
                        return new NDArray(new IntPtr(dataPtr), shape, dtype);
                    }
                default:
                    throw new NotImplementedException($"Can't find type: {_matType}");
            }
        }

        [MethodImpl(MethodImplOptions.NoOptimization)]
        private void DoNothing(IntPtr ptr)
        {
            var p = ptr;
        }

        public NDArray astype(TF_DataType dtype)
            => data.astype(dtype);

        public NDArray astype<T>()
            => data.astype(typeof(T).as_tf_dtype());

        protected override void FreeHandle()
        {
            cv2_native_api.core_Mat_delete(_handle);
        }

        public override string ToString()
        {
            return $"{shape} {MatType}";
        }

        public MatType FromType(Type type)
            => Type.GetTypeCode(type) switch
            {
                TypeCode.Int32 => MatType.CV_32SC1,
                TypeCode.Single => MatType.CV_32FC1,
                TypeCode.Double => MatType.CV_64FC1,
                _ => MatType.CV_8UC1
            };

        public MatType FromType(TF_DataType dtype)
            => dtype switch
            {
                TF_DataType.TF_INT32 => MatType.CV_32SC1,
                TF_DataType.TF_FLOAT => MatType.CV_32FC1,
                TF_DataType.TF_DOUBLE => MatType.CV_64FC1,
                _ => MatType.CV_8UC1
            };
    }
}
