using NumSharp;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    public partial class cv_api
    {
        public Mat cvtColor(Mat img, 
            ColorConversionCodes code, 
            int dstCnt = 0)
        {
            var dst = new Mat();
            cv2_native_api.imgproc_cvtColor(img.InputArray, dst.OutputArray, (int)code, dstCnt);
            return dst;
        }

        public Mat adaptiveThreshold(Mat img, 
            double maxValue, 
            AdaptiveThresholdTypes method, 
            ThresholdTypes type, 
            int blockSize, 
            double delta)
        {
            var dst = new Mat();
            cv2_native_api.imgproc_adaptiveThreshold(img.InputArray, 
                dst.OutputArray, 
                maxValue,
                (int)method,
                (int)type,
                blockSize,
                delta);
            return dst;
        }

        public (double, Mat) threshold(Mat img, double thresh, double maxval, ThresholdTypes type)
        {
            var dst = new Mat();
            cv2_native_api.imgproc_threshold(img.InputArray, dst.OutputArray, thresh, maxval, (int)type, out var ret);
            return (ret, dst);
        }

        public Mat pyrUp(Mat img)
        {
            var dst = new Mat();
            cv2_native_api.imgproc_pyrUp(img.InputArray,
                dst.OutputArray,
                new Size(),
                (int)BorderTypes.BORDER_DEFAULT);
            return dst;
        }

        public Mat pyrUp(Mat img,
            (int, int) dstSize,
            BorderTypes borderType = BorderTypes.BORDER_DEFAULT)
        {
            var dst = new Mat();
            cv2_native_api.imgproc_pyrUp(img.InputArray,
                dst.OutputArray,
                new Size(dstSize.Item1, dstSize.Item2),
                (int)borderType);
            return dst;
        }

        public Mat pyrDown(Mat img, 
            (int, int) dstSize,
            BorderTypes borderType = BorderTypes.BORDER_DEFAULT)
        {
            var dst = new Mat();
            cv2_native_api.imgproc_pyrDown(img.InputArray, 
                dst.OutputArray,
                new Size(dstSize.Item1, dstSize.Item2), 
                (int)borderType);
            return dst;
        }

        public Mat pyrDown(Mat img)
        {
            var dst = new Mat();
            cv2_native_api.imgproc_pyrDown(img.InputArray,
                dst.OutputArray,
                new Size(),
                (int)BorderTypes.BORDER_DEFAULT);
            return dst;
        }

        public Mat resize(Mat img, 
            (int, int) dsize, 
            double fx = 0, 
            double fy = 0, 
            InterpolationFlags interpolation = InterpolationFlags.INTER_LINEAR)
        {
            var dst = new Mat();
            cv2_native_api.imgproc_resize(img.InputArray, 
                dst.OutputArray, 
                new Size(dsize.Item1, dsize.Item2), 
                fx, 
                fy, 
                (int)interpolation);

            return dst;
        }

        /// <summary>
        /// Using rotation matrix to rotate a image.
        /// https://en.wikipedia.org/wiki/Rotation_matrix
        /// </summary>
        /// <param name="img"></param>
        /// <param name="center"></param>
        /// <param name="angle"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public Mat rotate(Mat img, 
            (int, int) center, 
            double angle, 
            double scale, 
            InterpolationFlags flags = InterpolationFlags.INTER_LINEAR,
            BorderTypes borderMode = BorderTypes.BORDER_CONSTANT)
        {
            cv2_native_api.imgproc_getRotationMatrix2D(new Point(center.Item1, center.Item2), 
                angle, 
                scale, 
                out var handle);
            
            cv2_native_api.core_Mat_size(img, out var size);

            var scalar = new Scalar();
            var dst = new Mat();
            var matrix2d = new Mat(handle);

            cv2_native_api.imgproc_warpAffine(img.InputArray, 
                dst.OutputArray, 
                matrix2d.InputArray, 
                size, 
                (int)flags, 
                (int)borderMode, scalar);

            return dst;
        }
    }
}
