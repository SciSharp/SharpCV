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
        public Mat this[(int, int) y, (int, int) x]
        {
            get
            {
                var cropped = _nd[$"{y.Item1}:{y.Item2}", $"{x.Item1}:{x.Item2}"];
                cv2_native_api.imgcodecs_imdecode_vector(cropped.GetData<byte>().ToArray(), cropped.size, IMREAD_COLOR.IMREAD_COLOR, out var handle);
                return new Mat(handle);
            }
        }
    }
}
