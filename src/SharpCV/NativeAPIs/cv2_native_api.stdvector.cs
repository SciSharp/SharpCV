using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    internal partial class cv2_native_api
    {
        #region uchar
        [Pure, DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_uchar_new1();
        [Pure, DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_uchar_new2(nuint size);
        [Pure, DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_uchar_new3([In] byte[] data, nuint dataLength);
        [Pure, DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern nuint vector_uchar_getSize(IntPtr vector);
        [Pure, DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr vector_uchar_getPointer(IntPtr vector);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_uchar_copy(IntPtr vector, IntPtr dst);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void vector_uchar_delete(IntPtr vector);
        #endregion

        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr vector_vector_Point_new1();
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr vector_vector_Point_getSize1(IntPtr vector);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void vector_vector_Point_delete(IntPtr vector);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void vector_vector_Point_getSize2(IntPtr vector, [In, Out] IntPtr[] size);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void vector_vector_Point_copy(IntPtr vec, IntPtr[] dst);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr vector_Mat_new1();
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void vector_Mat_delete(IntPtr vector);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int vector_Mat_getSize(IntPtr vector);
        [DllImport(OpenCvDllName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void vector_Mat_assignToArray(IntPtr vector, IntPtr[] array);
    }
}
