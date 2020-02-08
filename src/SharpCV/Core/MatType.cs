using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    /// <summary>
    /// https://docs.opencv.org/master/d0/d3a/classcv_1_1DataType.html
    /// CV_<bit-depth>{U|S|F}C(<number_of_channels>)
    /// </summary>
    public enum MatType
    {
        Unknown = -1,
        CV_8UC1 = 0,
        CV_32FC1 = 5,
        CV_32SC2 = 12,
        CV_8UC3 = 16
    }
}
