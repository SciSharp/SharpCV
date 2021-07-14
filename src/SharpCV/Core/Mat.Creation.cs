using System;
using System.Collections.Generic;
using System.Text;
using Tensorflow;
using Tensorflow.NumPy;

namespace SharpCV
{
    public partial class Mat
    {
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
                    cv2_native_api.core_Mat_new8((int)nd.shape[0], (int)nd.shape[1], FromType(nd.dtype), nd.data, new IntPtr(0), out _handle);
                    break;
                default:
                    throw new NotImplementedException("Not supported");
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
            // return new NDArray(np.@byte);
            throw new NotImplementedException("");
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
                case TF_DataType.TF_FLOAT:
                    {
                        cv2_native_api.core_Mat_data(_handle, out float* dataPtr);
                        dtype = TF_DataType.TF_FLOAT;
                        return new NDArray(new IntPtr(dataPtr), shape, dtype);
                    }
                default:
                    {
                        cv2_native_api.core_Mat_data(_handle, out byte* dataPtr);
                        dtype = TF_DataType.TF_UINT8;
                        return new NDArray(new IntPtr(dataPtr), shape, dtype);
                    }
            }
        }
    }
}
