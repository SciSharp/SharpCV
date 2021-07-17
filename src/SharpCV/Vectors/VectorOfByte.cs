using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SharpCV
{
	/// <summary> 
	/// </summary>
	public class VectorOfByte : DisposableObject, IStdVector<byte>
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public VectorOfByte()
		{
			_handle = cv2_native_api.vector_uchar_new1();
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="size"></param>
		public VectorOfByte(nuint size)
		{
			if (size < 0)
				throw new ArgumentOutOfRangeException(nameof(size));
			_handle = cv2_native_api.vector_uchar_new2(size);
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data"></param>
		public VectorOfByte(IEnumerable<byte> data)
		{
			if (data == null)
				throw new ArgumentNullException(nameof(data));
			var array = data.ToArray();
			_handle = cv2_native_api.vector_uchar_new3(array, (nuint)array.Length);
		}

		/// <summary>
		/// Releases unmanaged resources
		/// </summary>
		protected override void FreeHandle()
		{
			cv2_native_api.vector_uchar_delete(_handle);
			//base.DisposeUnmanaged();
		}

		public IntPtr Handle => _handle;

		/// <summary>
		/// vector.size()
		/// </summary>
		public int Size
		{
			get
			{
				var res = cv2_native_api.vector_uchar_getSize(_handle);
				GC.KeepAlive(this);
				return (int)res;
			}
		}

		/// <summary>
		/// &amp;vector[0]
		/// </summary>
		public IntPtr ElemPtr
		{
			get
			{
				var res = cv2_native_api.vector_uchar_getPointer(_handle);
				GC.KeepAlive(this);
				return res;
			}
		}

		/// <summary>
		/// Converts std::vector to managed array
		/// </summary>
		/// <returns></returns>
		public byte[] ToArray()
		{
			var size = Size;
			if (size == 0)
			{
				return Array.Empty<byte>();
			}
			var dst = new byte[size];
			Marshal.Copy(ElemPtr, dst, 0, dst.Length);
			GC.KeepAlive(this); // ElemPtr is IntPtr to memory held by this object, so
								// make sure we are not disposed until finished with copy.
			return dst;
		}
	}
}
