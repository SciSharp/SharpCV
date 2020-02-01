using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SharpCV
{
    public class ArrayAddress2<T> : DisposableObject
        where T : unmanaged
    {
        private readonly T[][] array;
        private readonly GCHandle[] gch;
        private readonly IntPtr[] ptr;

        public ArrayAddress2(T[][] array)
        {
            this.array = array ?? throw new ArgumentNullException(nameof(array));

            ptr = new IntPtr[array.Length];
            gch = new GCHandle[array.Length];
            for (var i = 0; i < array.Length; i++)
            {
                var elem = array[i];
                if (elem == null)
                    throw new ArgumentException($"array[{i}] is not valid array object.");
                
                gch[i] = GCHandle.Alloc(elem, GCHandleType.Pinned);
                ptr[i] = gch[i].AddrOfPinnedObject();
            }
        }

        public ArrayAddress2(IEnumerable<IEnumerable<T>> enumerable)
            : this(enumerable.Select(x => x.ToArray()).ToArray())
        {
        }

        protected override void FreeHandle()
        {
            foreach (var h in gch)
                if (h.IsAllocated)
                    h.Free();
        }

        public IntPtr[] Pointer => ptr;

        public static implicit operator IntPtr[](ArrayAddress2<T> self)
            => self.Pointer;

        int[] _lengths = null;
        public int[] Dim2Lengths
        {
            get
            {
                if(_lengths == null)
                {
                    _lengths = new int[array.Length];
                    for (var i = 0; i < array.Length; i++)
                        _lengths[i] = array[i].Length;
                }

                return _lengths;
            }
        }
    }
}