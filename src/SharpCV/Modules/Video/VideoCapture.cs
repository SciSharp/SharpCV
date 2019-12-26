using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    public class VideoCapture : DisposableObject
    {
        public VideoCapture(IntPtr handle)
        {
            _handle = handle;
        }

        public (bool, Mat) read()
        {
            var dst = new Mat();
            cv2_native_api.videoio_VideoCapture_read(_handle, dst.OutputArray, out var output);
            return (output != 0, dst);
        }
    }
}
