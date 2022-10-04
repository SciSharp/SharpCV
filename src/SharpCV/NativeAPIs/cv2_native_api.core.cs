using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    internal partial class cv2_native_api
    {
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_Mat_new1(out IntPtr returnValue);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_Mat_new7(IntPtr mat, Rect rect, out IntPtr returnValue);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_Mat_new8(int rows, int cols, MatType type, IntPtr data, IntPtr step, out IntPtr returnValue);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_Mat_cols(IntPtr mat, out int output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_Mat_rows(IntPtr mat, out int output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_Mat_ptr2d(IntPtr mat, int row, int col, out IntPtr output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_Mat_dims(IntPtr mat, out int output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_Mat_sizeAt(IntPtr mat, int dim, out int output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_Mat_type(IntPtr mat, out MatType output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe void core_Mat_data(IntPtr mat, out byte* output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe void core_Mat_data(IntPtr mat, out int* output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe void core_Mat_data(IntPtr mat, out float* output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_Mat_channels(IntPtr mat, out int output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_Mat_depth(IntPtr mat, out int output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_Mat_delete(IntPtr mat);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_Mat_size(IntPtr mat, out Size output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_Mat_elemSize(IntPtr mat, out int output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_InputArray_new_byMat(IntPtr mat, out IntPtr output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_OutputArray_new_byMat(IntPtr mat, out IntPtr output);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_rotate(IntPtr mat, IntPtr dst, int flags);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_flip(IntPtr mat, IntPtr dst, int mode);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_hconcat1([MarshalAs(UnmanagedType.LPArray)] IntPtr[] src, uint nsrc, IntPtr dst);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_vconcat1([MarshalAs(UnmanagedType.LPArray)] IntPtr[] src, uint nsrc, IntPtr dst);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_hconcat2(IntPtr mat1, IntPtr mat2, IntPtr dst);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_split(IntPtr src, IntPtr mv);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_vconcat2(IntPtr mat1, IntPtr mat2, IntPtr dst);

        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_convertScaleAbs(IntPtr src, IntPtr dst, double alpha, double beta);

        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void core_addWeighted(IntPtr src1, double alpha, IntPtr src2, double beta, double gamma, IntPtr dst, int dtype);
    }
}
