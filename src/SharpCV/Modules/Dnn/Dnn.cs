using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    public class Dnn
    {
        public Net readNetFromTensorflow(string model, string config = null)
        {
            cv2_native_api.dnn_readNetFromTensorflow(model, config, out var handle);
            return new Net(handle);
        }

        public Net ReadNetFromTorch(string model, bool isBinary = true)
        {
            cv2_native_api.dnn_readNetFromTorch(model, isBinary, out var handle);
            return new Net(handle);
        }

        public Net ReadNetFromONNX(string model)
        {
            cv2_native_api.dnn_readNetFromONNX(model, out var handle);
            return new Net(handle);
        }

        /// <summary>
        /// Creates 4-dimensional blob from image.
        /// </summary>
        /// <param name="image">input image (with 1-, 3- or 4-channels).</param>
        /// <param name="scaleFactor"></param>
        /// <param name="size">spatial size for output image</param>
        /// <param name="mean">scalar with mean values which are subtracted from channels.</param>
        /// <param name="swapRB">flag which indicates that swap first and last channels in 3-channel image is necessary.</param>
        /// <param name="crop">flag which indicates whether image will be cropped after resize or not</param>
        /// <returns></returns>
        public Mat blobFromImage(Mat image, double scaleFactor, (int, int) size, Scalar? mean = null, bool swapRB = true, bool crop = true)
        {
            cv2_native_api.dnn_blobFromImage(image,
                scaleFactor,
                new Size(size.Item1, size.Item2),
                mean ?? new Scalar(),
                swapRB, 
                crop,
                out var handle);
            return new Mat(handle, type: NumSharp.NPTypeCode.Single);
        }
    }
}
