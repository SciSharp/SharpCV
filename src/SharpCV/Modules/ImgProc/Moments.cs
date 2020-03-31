using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    public partial class Moments
    {
        /// <summary>
        /// spatial moments
        /// </summary>
        public double M00, M10, M01, M20, M11, M02, M30, M21, M12, M03;

        /// <summary>
        /// central moments
        /// </summary>
        public double Mu20, Mu11, Mu02, Mu30, Mu21, Mu12, Mu03;

        /// <summary>
        /// central normalized moments
        /// </summary>
        public double Nu20, Nu11, Nu02, Nu30, Nu21, Nu12, Nu03;

        public Moments(Mat img, bool binaryImage = false)
        {
            cv2_native_api.imgproc_moments(img.InputArray, binaryImage ? 1 : 0, out var m);
            Initialize(m.m00, m.m10, m.m01, m.m20, m.m11, m.m02, m.m30, m.m21, m.m12, m.m03);
        }

        private void Initialize(double m00, double m10, double m01, double m20, double m11,
                       double m02, double m30, double m21, double m12, double m03)
        {
            M00 = m00;
            M10 = m10;
            M01 = m01;
            M20 = m20;
            M11 = m11;
            M02 = m02;
            M30 = m30;
            M21 = m21;
            M12 = m12;
            M03 = m03;

            double cx = 0, cy = 0, invM00 = 0;
            if (Math.Abs(M00) > double.Epsilon)
            {
                invM00 = 1.0 / M00;
                cx = M10 * invM00;
                cy = M01 * invM00;
            }

            Mu20 = M20 - M10 * cx;
            Mu11 = M11 - M10 * cy;
            Mu02 = M02 - M01 * cy;

            Mu30 = M30 - cx * (3 * Mu20 + cx * M10);
            Mu21 = M21 - cx * (2 * Mu11 + cx * M01) - cy * Mu20;
            Mu12 = M12 - cy * (2 * Mu11 + cy * M10) - cx * Mu02;
            Mu03 = M03 - cy * (3 * Mu02 + cy * M01);

            var invSqrtM00 = Math.Sqrt(Math.Abs(invM00));
            var s2 = invM00 * invM00;
            var s3 = s2 * invSqrtM00;

            Nu20 = Mu20 * s2;
            Nu11 = Mu11 * s2;
            Nu02 = Mu02 * s2;
            Nu30 = Mu30 * s3;
            Nu21 = Mu21 * s3;
            Nu12 = Mu12 * s3;
            Nu03 = Mu03 * s3;
        }
    }
}
