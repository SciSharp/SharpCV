using NumSharp;
using System;
using System.Collections.Generic;
using System.Text;

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
                    cv2_native_api.core_Mat_new8(nd.shape[0], nd.shape[1], FromType(nd.dtype), new IntPtr(nd.Unsafe.Storage.Address), new IntPtr(0), out _handle);
                    break;
                default:
                    throw new NotImplementedException("Not supported");
            }
        }
    }
}
