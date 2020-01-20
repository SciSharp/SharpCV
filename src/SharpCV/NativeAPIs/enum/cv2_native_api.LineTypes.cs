using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    /// <summary>
    /// modules\imgproc\include\opencv2\imgproc.hpp
    /// </summary>
    public enum LineTypes
    {
        FILLED = -1,
        LINE_4 = 4, //!< 4-connected line
        LINE_8 = 8, //!< 8-connected line
        LINE_AA = 16 //!< antialiased line
    };
}
