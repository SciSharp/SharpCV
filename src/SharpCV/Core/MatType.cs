using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    /// <summary>
    /// https://docs.opencv.org/master/d0/d3a/classcv_1_1DataType.html
    /// https://gist.github.com/pabloduque0/456cb62d02a027d3a458f31cdec6771d
    /// CV_<bit-depth>{U|S|F}C(<number_of_channels>)
    /// 
    /// A Mapping of Type to Numbers in OpenCV
    ///         C1  C2  C3  C4
    /// CV_8U	0	8	16	24
    /// CV_8S	1	9	17	25
    /// CV_16U	2	10	18	26
    /// CV_16S	3	11	19	27
    /// CV_32S	4	12	20	28
    /// CV_32F	5	13	21	29
    /// CV_64F	6	14	22	30
    /// </summary>
    public enum MatType
    {
        Unknown = -1,
        CV_8UC1 = 0,
        CV_8UC3 = 16,
        CV_32SC1 = 4,
        CV_32FC1 = 5,
        CV_32SC2 = 12,
        CV_64FC1 = 6
    }
}
