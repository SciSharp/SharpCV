using NumSharp;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    public partial class cv_api
    {
        /// <summary>
        /// Image Denoising
        /// Non-local Means Denoisin
        /// works with a single grayscale images
        /// https://opencv-python-tutroals.readthedocs.io/en/latest/py_tutorials/py_photo/py_non_local_means/py_non_local_means.html
        /// </summary>
        /// <returns></returns>
        public Mat fastNlMeansDenoising(Mat src, 
            float h = 3,
            int templateWindowSize = 7, 
            int searchWindowSize = 21)
        {
            var dst = new Mat();
            cv2_native_api.photo_fastNlMeansDenoising(src.InputArray, dst.OutputArray, h, templateWindowSize, searchWindowSize);
            return dst;
        }

        public Mat fastNlMeansDenoisingColored(Mat src,
            float h = 3,
            float hColor = 3,
            int templateWindowSize = 7,
            int searchWindowSize = 21)
        {
            var dst = new Mat();
            cv2_native_api.photo_fastNlMeansDenoisingColored(src.InputArray, dst.OutputArray, h, hColor, templateWindowSize, searchWindowSize);
            return dst;
        }
    }
}
