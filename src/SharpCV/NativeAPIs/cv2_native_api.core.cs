using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    public partial class cv2_native_api
    {
        [DllImport(OpenCvDllName)]
        internal static extern void core_Mat_new1(out IntPtr returnValue);
        [DllImport(OpenCvDllName)]
        internal static extern void core_Mat_cols(IntPtr self, out int output);
        [DllImport(OpenCvDllName)]
        internal static extern void core_Mat_rows(IntPtr self, out int output);
        [DllImport(OpenCvDllName)]
        internal static extern void core_Mat_type(IntPtr self, out int output);
        [DllImport(OpenCvDllName)]
        internal static extern unsafe void core_Mat_data(IntPtr self, out byte* output);
        [DllImport(OpenCvDllName)]
        internal static extern void core_Mat_channels(IntPtr self, out int output);
        [DllImport(OpenCvDllName)]
        internal static extern void core_Mat_delete(IntPtr prt);
        [DllImport(OpenCvDllName)]
        internal static extern void core_InputArray_new_byMat(IntPtr mat, out IntPtr output);
        [DllImport(OpenCvDllName)]
        internal static extern void core_OutputArray_new_byMat(IntPtr mat, out IntPtr output);
    }
}
