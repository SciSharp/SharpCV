using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    /// <summary>
    /// modules\imgproc\include\opencv2\imgproc.hpp
    /// </summary>
    public enum AdaptiveThresholdTypes
    {
        /** the threshold value \f$T(x,y)\f$ is a mean of the \f$\texttt{blockSize} \times
        \texttt{blockSize}\f$ neighborhood of \f$(x, y)\f$ minus C */
        ADAPTIVE_THRESH_MEAN_C = 0,
        /** the threshold value \f$T(x, y)\f$ is a weighted sum (cross-correlation with a Gaussian
        window) of the \f$\texttt{blockSize} \times \texttt{blockSize}\f$ neighborhood of \f$(x, y)\f$
        minus C . The default sigma (standard deviation) is used for the specified blockSize . See
        #getGaussianKernel*/
        ADAPTIVE_THRESH_GAUSSIAN_C = 1
    };
}
