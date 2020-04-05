using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    internal partial class cv2_native_api
    {
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void imgcodecs_imread(string filename, int flags, out IntPtr output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void imgcodecs_imwrite(string filename, IntPtr img, [In] int[] @params, int paramsLength, out int output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void imgcodecs_imdecode_vector(byte[] buf, int bufLength, IMREAD_COLOR flags, out IntPtr output);
    }
}
