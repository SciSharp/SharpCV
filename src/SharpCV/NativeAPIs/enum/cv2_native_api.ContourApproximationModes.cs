using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    /// <summary>
    /// opencv2\imgproc.hpp
    /// </summary>
    public enum ContourApproximationModes
    {
        /** stores absolutely all the contour points. That is, any 2 subsequent points (x1,y1) and
        (x2,y2) of the contour will be either horizontal, vertical or diagonal neighbors, that is,
        max(abs(x1-x2),abs(y2-y1))==1. */
        CHAIN_APPROX_NONE = 1,
        /** compresses horizontal, vertical, and diagonal segments and leaves only their end points.
        For example, an up-right rectangular contour is encoded with 4 points. */
        CHAIN_APPROX_SIMPLE = 2,
        /** applies one of the flavors of the Teh-Chin chain approximation algorithm @cite TehChin89 */
        CHAIN_APPROX_TC89_L1 = 3,
        /** applies one of the flavors of the Teh-Chin chain approximation algorithm @cite TehChin89 */
        CHAIN_APPROX_TC89_KCOS = 4
    };
}
