using System;
using System.Collections.Generic;
using System.Text;
using Tensorflow.NumPy;

namespace SharpCV
{
    public partial class Mat
    {
        public static implicit operator IntPtr(Mat mat)
            => mat._handle;

        public static implicit operator Mat(IntPtr handle)
            => new Mat(handle);

        public static implicit operator NDArray(Mat mat)
            => mat.data;

        public static implicit operator Mat(NDArray nd)
            => new Mat(nd);
    }
}
