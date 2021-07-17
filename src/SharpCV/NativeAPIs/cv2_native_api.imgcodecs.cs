using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

        internal static unsafe extern void imgcodecs_imdecode_vector(byte* buf, int bufLength, IMREAD_COLOR flags, out IntPtr output);

        // Do not consider that "ext" may not be ASCII characters
        [Pure, DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = true)]
        internal static extern int imgcodecs_imencode_vector(
            [MarshalAs(UnmanagedType.LPStr)] string ext, IntPtr img, IntPtr buf, [In] int[] @params, int paramsLength, out int returnValue);

    }
}
