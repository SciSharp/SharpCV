using System;

namespace SharpCV
{
    public class VectorOfVectorPoint : DisposableObject
    {
        public VectorOfVectorPoint()
        {
            _handle = cv2_native_api.vector_vector_Point_new1();
        }

        public VectorOfVectorPoint(IntPtr ptr)
        {
            _handle = ptr;
        }

        protected override void FreeHandle()
        {
            cv2_native_api.vector_vector_Point_delete(_handle);
        }

        public int Size1
        {
            get
            {
                var res = cv2_native_api.vector_vector_Point_getSize1(_handle).ToInt32();
                GC.KeepAlive(this);
                return res;
            }
        }

        public int Size => Size1;

        public long[] Size2
        {
            get
            {
                var size1 = Size1;
                var size2Org = new IntPtr[size1];
                cv2_native_api.vector_vector_Point_getSize2(_handle, size2Org);
                GC.KeepAlive(this);
                var size2 = new long[size1];
                for (var i = 0; i < size1; i++)
                {
                    size2[i] = size2Org[i].ToInt64();
                }
                return size2;
            }
        }

        public Point[][] ToArray()
        {
            var size1 = Size1;
            if (size1 == 0)
                return new Point[0][];
            var size2 = Size2;

            var ret = new Point[size1][];
            for (var i = 0; i < size1; i++)
            {
                ret[i] = new Point[size2[i]];
            }
            using (var retPtr = new ArrayAddress2<Point>(ret))
            {
                cv2_native_api.vector_vector_Point_copy(_handle, retPtr);
                GC.KeepAlive(this);
            }
            return ret;
        }
    }
}
