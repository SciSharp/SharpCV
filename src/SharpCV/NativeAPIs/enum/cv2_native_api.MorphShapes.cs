using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    /// <summary>
    /// opencv2\imgproc.hpp
    /// </summary>
    public enum MorphShapes
    {
        MORPH_RECT = 0, //!< a rectangular structuring element:  \f[E_{ij}=1\f]
        MORPH_CROSS = 1, //!< a cross-shaped structuring element:
                         //!< \f[E_{ij} =  \fork{1}{if i=\texttt{anchor.y} or j=\texttt{anchor.x}}{0}{otherwise}\f]
        MORPH_ELLIPSE = 2 //!< an elliptic structuring element, that is, a filled ellipse inscribed
                          //!< into the rectangle Rect(0, 0, esize.width, 0.esize.height)
    };
}
