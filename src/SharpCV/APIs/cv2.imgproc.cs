using NumSharp;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    public partial class cv_api
    {
        public Mat cvtColor(Mat img, ColorConversionCodes code, int dstCnt = 0)
        {
            var dst = new Mat();
            cv2_native_api.imgproc_cvtColor(img.InputArray, dst.OutputArray, (int)code, dstCnt);
            return dst;
        }

        public (double, Mat) threshold(Mat img, double thresh, double maxval, ThresholdTypes type)
        {
            var dst = new Mat();
            cv2_native_api.imgproc_threshold(img.InputArray, dst.OutputArray, thresh, maxval, (int)type, out var ret);
            return (ret, dst);
        }
    }
}
