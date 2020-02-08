using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpCV
{
    /// <summary>
    /// 
    /// </summary>
    public class VectorOfMat : DisposableObject
    {
        public VectorOfMat()
        {
            _handle = cv2_native_api.vector_Mat_new1();
        }

        public VectorOfMat(IntPtr ptr) => _handle = ptr;

        protected override void FreeHandle()
        {
            cv2_native_api.vector_Mat_delete(_handle);
        }

        public int Size => cv2_native_api.vector_Mat_getSize(_handle);

        public Mat[] ToArray() => ToArray<Mat>();

        public T[] ToArray<T>()
            where T : Mat, new()
        {
            var size = Size;
            if (size == 0)
                return new T[0];

            var dst = new T[size];
            var dstPtr = new IntPtr[size];
            for (var i = 0; i < size; i++)
            {
                var m = new T();
                dst[i] = m;
                dstPtr[i] = m;
            }
            cv2_native_api.vector_Mat_assignToArray(_handle, dstPtr);

            return dst;
        }
    }
}
