using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    public partial class cv2_native_api
    {
        [DllImport(OpenCvDllName)]
        internal static extern void imgproc_cvtColor(IntPtr src, IntPtr dst, int code, int dstCnt);
        [DllImport(OpenCvDllName)]
        internal static extern void imgproc_threshold(IntPtr src, IntPtr dst, double thresh, double maxval, int type, out double returnValue);
        [DllImport(OpenCvDllName)]
        internal static extern void imgproc_resize(IntPtr src, IntPtr dst, Size dsize, double fx, double fy, int interpolation);
    }
}
