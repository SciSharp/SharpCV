using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    /// <summary>
    /// modules\core\include\opencv2\core\base.hpp
    /// </summary>
    public enum BorderTypes
    {
        BORDER_CONSTANT = 0, //!< `iiiiii|abcdefgh|iiiiiii`  with some specified `i`
        BORDER_REPLICATE = 1, //!< `aaaaaa|abcdefgh|hhhhhhh`
        BORDER_REFLECT = 2, //!< `fedcba|abcdefgh|hgfedcb`
        BORDER_WRAP = 3, //!< `cdefgh|abcdefgh|abcdefg`
        BORDER_REFLECT_101 = 4, //!< `gfedcb|abcdefgh|gfedcba`
        BORDER_TRANSPARENT = 5, //!< `uvwxyz|abcdefgh|ijklmno`

        BORDER_REFLECT101 = BORDER_REFLECT_101, //!< same as BORDER_REFLECT_101
        BORDER_DEFAULT = BORDER_REFLECT_101, //!< same as BORDER_REFLECT_101
        BORDER_ISOLATED = 16 //!< do not look outside of ROI
    };
}
