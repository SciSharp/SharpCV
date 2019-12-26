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
                    _nd = WrapWithNDArray();
                return _nd;
            }
        }

        public Type dtype => data.dtype;
        public Shape shape => data.Shape;
        public int size => data.size;

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

        public Mat()
        {
            cv2_native_api.core_Mat_new1(out _handle);
        }

        public Mat(IntPtr handle)
        {
            _handle = handle;
        }

        //this method copies Mat to a new NDArray
        private unsafe NDArray CopyToNDArray()
        {
            cv2_native_api.core_Mat_cols(_handle, out var width);
            cv2_native_api.core_Mat_rows(_handle, out var height);
            cv2_native_api.core_Mat_type(_handle, out var type);
            cv2_native_api.core_Mat_data(_handle, out var data);

            var nd = new NDArray(NPTypeCode.Byte, (1, height, width, type), fillZeros: false);
            new UnmanagedMemoryBlock<byte>(data, nd.size)
                .CopyTo(nd.Unsafe.Address);

            return nd;
        }

        //this method wraps without copying Mat.
        private unsafe NDArray WrapWithNDArray()
        {
            cv2_native_api.core_Mat_cols(_handle, out var width);
            cv2_native_api.core_Mat_rows(_handle, out var height);
            cv2_native_api.core_Mat_channels(_handle, out var channels);
            cv2_native_api.core_Mat_data(_handle, out var dataPtr);

            Shape shape = (height, width, channels);
            // we pass donothing as it keeps reference to src preventing its disposal by GC
            var block = new UnmanagedMemoryBlock<byte>(dataPtr, shape.Size, () => DoNothing(_handle));
            var storage = new UnmanagedStorage(new ArraySlice<byte>(block), shape); 
            return new NDArray(storage);
        }

        [MethodImpl(MethodImplOptions.NoOptimization)]
        private void DoNothing(IntPtr ptr)
        {
            var p = ptr;
        }

        protected override void FreeHandle()
        {
            cv2_native_api.core_Mat_delete(_handle);
        }

        public static implicit operator IntPtr(Mat mat)
            => mat._handle;

        public static implicit operator Mat(IntPtr handle)
            => new Mat(handle);
    }
}
