using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    internal partial class cv2_native_api
    {
        [DllImport(OpenCvDllName)]
        internal static extern void photo_fastNlMeansDenoising(IntPtr src, IntPtr dst, float h,
            int templateWindowSize, int searchWindowSize);

        [DllImport(OpenCvDllName)]
        internal static extern void photo_fastNlMeansDenoisingColored(IntPtr src, IntPtr dst,
            float h, float hColor, int templateWindowSize, int searchWindowSize);
    }
}
