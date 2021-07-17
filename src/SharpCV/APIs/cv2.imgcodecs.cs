using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    public partial class cv_api
    {
        public Mat imread(string filename, IMREAD_COLOR flags = IMREAD_COLOR.IMREAD_COLOR)
        {
            cv2_native_api.imgcodecs_imread(filename, (int)flags, out var handle);
            return new Mat(handle);
        }

        public bool imwrite(string filename, Mat img, params int[] @params)
        {
            cv2_native_api.imgcodecs_imwrite(filename, img, @params, @params.Length, out var output);
            return output != 0;
        }

        public Mat imcrop(Mat src, Rect rect)
        {
            cv2_native_api.core_Mat_new7(src, rect, out var handle);
            return new Mat(handle);
        }

        /// <summary>
        /// Reads image from the specified buffer in memory.
        /// </summary>
        /// <param name="span">The input slice of bytes.</param>
        /// <param name="flags">The same flags as in imread</param>
        /// <returns></returns>
        public static Mat ImDecode(ReadOnlySpan<byte> span, IMREAD_COLOR flags)
        {
            if (span.IsEmpty)
                throw new ArgumentException("Empty span", nameof(span));

            unsafe
            {
                fixed (byte* pBuf = span)
                {
                        cv2_native_api.imgcodecs_imdecode_vector(pBuf, span.Length, flags, out var ret);
                    return new Mat(ret);
                }
            }
        }

        /// <summary>
        /// Compresses the image and stores it in the memory buffer
        /// </summary>
        /// <param name="ext">The file extension that defines the output format</param>
        /// <param name="img">The image to be written</param>
        /// <param name="buf">Output buffer resized to fit the compressed image.</param>
        /// <param name="prms">Format-specific parameters.</param>
        public static bool ImEncode(string ext, Mat img, out byte[] buf, int[]? prms = null)
        {
            if (string.IsNullOrEmpty(ext))
                throw new ArgumentNullException(nameof(ext));
            if (img == null)
                throw new ArgumentNullException(nameof(img));
            if (prms == null)
                prms = Array.Empty<int>();
			//img.ThrowIfDisposed();

			using var bufVec = new VectorOfByte();
			var exe_result =
                cv2_native_api.imgcodecs_imencode_vector(ext, img.OutputArray, bufVec.Handle, prms, prms.Length, out var ret);
            GC.KeepAlive(img);

			buf = bufVec.ToArray();

			return ret != 0;
        }

    }
}
