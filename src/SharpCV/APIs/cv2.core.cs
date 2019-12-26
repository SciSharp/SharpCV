using NumSharp;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    public partial class cv_api
    {
        public Mat rotate(Mat img, RotateFlags flags)
        {
            var dst = new Mat();
            cv2_native_api.core_rotate(img.InputArray, dst.OutputArray, (int)flags);
            return dst;
        }
    }
}
