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
        internal static extern void highgui_namedWindow(string winName, int flags);
        [DllImport(OpenCvDllName)]
        internal static extern void highgui_resizeWindow(string winName, int width, int height);
        [DllImport(OpenCvDllName)]
        internal static extern void highgui_waitKey(int delay, out int output);
        [DllImport(OpenCvDllName)]
        internal static extern void highgui_destroyAllWindows();
    }
}
