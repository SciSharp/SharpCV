using NumSharp;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    public partial class cv_api
    {
        public VideoCapture VideoCapture(string fileName, VideoCaptureAPIs api = VideoCaptureAPIs.CAP_ANY)
        {
            cv2_native_api.videoio_VideoCapture_new2(fileName, (int)api, out var handle);
            return new VideoCapture(handle);
        }
    }
}
