using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    internal partial class cv2_native_api
    {
        [DllImport(OpenCvDllName)]
        internal static extern void imgproc_cvtColor(IntPtr src, IntPtr dst, int code, int dstCnt);
        [DllImport(OpenCvDllName)]
        internal static extern void imgproc_threshold(IntPtr src, IntPtr dst, double thresh, double maxval, int type, out double output);
        [DllImport(OpenCvDllName)]
        internal static extern void imgproc_resize(IntPtr src, IntPtr dst, Size dsize, double fx, double fy, int interpolation);
        [DllImport(OpenCvDllName)]
        internal static extern void imgproc_getRotationMatrix2D(Point center, double angle, double scale, out IntPtr output);
        [DllImport(OpenCvDllName)]
        internal static extern void imgproc_warpAffine(IntPtr src, IntPtr dst, IntPtr m, Size dsize, int flags, int borderMode, Scalar borderValue);
        [DllImport(OpenCvDllName)]
        internal static extern void imgproc_adaptiveThreshold(IntPtr src, IntPtr dst, double maxValue, int method, int type, int blockSize, double delta);
    }
}
