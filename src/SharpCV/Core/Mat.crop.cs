using NumSharp;
using NumSharp.Backends;
using NumSharp.Backends.Unmanaged;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    public partial class Mat
    {
        public unsafe Mat this[(int, int) y, (int, int) x]
        {
            get
            {
                // var cropped = data[new Slice(y.Item1, y.Item2), new Slice(x.Item1, x.Item2)];
                 cv2_native_api.core_Mat_new7(_handle, new Rect(x.Item1, y.Item1, x.Item2 - x.Item1, y.Item2 - y.Item1), out var handle);
                // cv2_native_api.imgcodecs_imdecode_vector(cropped.GetData<byte>().ToArray(), cropped.size, IMREAD_COLOR.IMREAD_COLOR, out var handle);
                return new Mat(handle);
            }
        }
    }
}
