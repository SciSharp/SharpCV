using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    internal partial class cv2_native_api
    {
        [DllImport(OpenCvDllName)]
        internal static extern void highgui_imshow(string winName, IntPtr mat);
        [DllImport(OpenCvDllName)]
        internal static extern void highgui_waitKey(int delay, out int output); 
    }
}
