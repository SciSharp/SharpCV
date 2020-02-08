using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    internal partial class cv2_native_api
    {
        [DllImport(OpenCvDllName)]
        internal static extern IntPtr vector_vector_Point_new1();
        [DllImport(OpenCvDllName)]
        internal static extern IntPtr vector_vector_Point_getSize1(IntPtr vector);
        [DllImport(OpenCvDllName)]
        internal static extern void vector_vector_Point_delete(IntPtr vector);
        [DllImport(OpenCvDllName)]
        internal static extern void vector_vector_Point_getSize2(IntPtr vector, [In, Out] IntPtr[] size);
        [DllImport(OpenCvDllName)]
        internal static extern void vector_vector_Point_copy(IntPtr vec, IntPtr[] dst);
        [DllImport(OpenCvDllName)]
        internal static extern IntPtr vector_Mat_new1();
        [DllImport(OpenCvDllName)]
        internal static extern void vector_Mat_delete(IntPtr vector);
        [DllImport(OpenCvDllName)]
        internal static extern int vector_Mat_getSize(IntPtr vector);
        [DllImport(OpenCvDllName)]
        internal static extern void vector_Mat_assignToArray(IntPtr vector, IntPtr[] array);
    }
}
