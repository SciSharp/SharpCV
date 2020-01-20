using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    public class Net : DisposableObject
    {
        public Net()
        {
            cv2_native_api.dnn_Net_new(out _handle);
        }

        public Net(IntPtr handle)
        {
            _handle = handle;
        }

        public void setInput(Mat blob, string name = "")
        {
            cv2_native_api.dnn_Net_setInput(_handle, blob, name);
        }

        public Mat forward(string outputName = "")
        {
            cv2_native_api.dnn_Net_forward1(_handle, outputName, out var handle);
            return new Mat(handle);
        }

        protected override void FreeHandle()
        {
            cv2_native_api.dnn_Net_delete(_handle);
        }

        public static implicit operator IntPtr(Net net)
            => net._handle;

        public static implicit operator Net(IntPtr handle)
            => new Net(handle);
    }
}
