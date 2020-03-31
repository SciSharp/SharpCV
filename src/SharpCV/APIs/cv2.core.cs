using NumSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    public partial class cv_api
    {
        public Mat flip(Mat img, FLIP_MODE mode)
        {
            var dst = new Mat();
            cv2_native_api.core_flip(img.InputArray, dst.OutputArray, (int)mode);
            return dst;
        }

        public Mat rotate(Mat img, RotateFlags flags)
        {
            var dst = new Mat();
            cv2_native_api.core_rotate(img.InputArray, dst.OutputArray, (int)flags);
            return dst;
        }

        public Mat[] split(Mat img)
        {
            using (var vec = new VectorOfMat())
            {
                cv2_native_api.core_split(img, vec);
                return vec.ToArray();
            }
        }

        public Mat hconcat(params Mat[] imgs)
        {
            var dst = new Mat();
            cv2_native_api.core_hconcat1(imgs.Select(x => (IntPtr)x).ToArray(), (uint)imgs.Length, dst.OutputArray);
            return dst;
        }

        public Mat vconcat(params Mat[] imgs)
        {
            var dst = new Mat();
            cv2_native_api.core_vconcat1(imgs.Select(x => (IntPtr)x).ToArray(), (uint)imgs.Length, dst.OutputArray);
            return dst;
        }
    }
}
