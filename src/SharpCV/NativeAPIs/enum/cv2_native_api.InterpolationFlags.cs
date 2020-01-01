using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    /// <summary>
    /// modules\imgproc\include\opencv2\imgproc.hpp
    /// </summary>
    public enum InterpolationFlags
    {
        /** nearest neighbor interpolation */
        INTER_NEAREST = 0,
        /** bilinear interpolation */
        INTER_LINEAR = 1,
        /** bicubic interpolation */
        INTER_CUBIC = 2,
        /** resampling using pixel area relation. It may be a preferred method for image decimation, as
        it gives moire'-free results. But when the image is zoomed, it is similar to the INTER_NEAREST
        method. */
        INTER_AREA = 3,
        /** Lanczos interpolation over 8x8 neighborhood */
        INTER_LANCZOS4 = 4,
        /** Bit exact bilinear interpolation */
        INTER_LINEAR_EXACT = 5,
        /** mask for interpolation codes */
        INTER_MAX = 7,
        /** flag, fills all of the destination image pixels. If some of them correspond to outliers in the
        source image, they are set to zero */
        WARP_FILL_OUTLIERS = 8,
        /** flag, inverse transformation

        For example, #linearPolar or #logPolar transforms:
        - flag is __not__ set: \f$dst( \rho , \phi ) = src(x,y)\f$
        - flag is set: \f$dst(x,y) = src( \rho , \phi )\f$
        */
        WARP_INVERSE_MAP = 16
    };
}
