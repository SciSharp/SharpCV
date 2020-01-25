using NumSharp;
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
    }
}
