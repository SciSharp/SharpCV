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

        public unsafe NDArray this[int row, int col]
        {
            get
            {
                cv2_native_api.core_Mat_ptr2d(_handle, row, col, out var output);
                return ndim switch
                {
                    2 => NDArray.Scalar(*(byte*)output),
                    3 => np.array(*(byte*)output, *((byte*)output + 1), *((byte*)output + 2)),
                    _ => throw new NotImplementedException($"Can't found index access for ndim: {ndim}")
                };
            }

            set
            {
                // BGR format
            }
        }

        public unsafe byte this[int row, int col, int channel]
        {
            get
            {
                cv2_native_api.core_Mat_ptr2d(_handle, row, col, out var output);
                return channel switch
                {
                    0 => *(byte*)output,
                    1 => *((byte*)output + 1),
                    2 => *((byte*)output + 2),
                    _ => throw new NotImplementedException($"Channel can't exceed {channel}")
                };
            }
        }
    }
}
