using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    internal partial class cv2_native_api
    {
        [DllImport(OpenCvDllName)]
        internal static extern void videoio_VideoCapture_new2(string filename, int api, out IntPtr output);
        [DllImport(OpenCvDllName)]
        internal static extern void videoio_VideoCapture_read(IntPtr vid, IntPtr frame, out int output);
    }
}
