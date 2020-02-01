using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    /// <summary>
    /// opencv2\imgproc.hpp
    /// </summary>
    public enum RetrievalModes
    {
        /** retrieves only the extreme outer contours. It sets `hierarchy[i][2]=hierarchy[i][3]=-1` for
        all the contours. */
        RETR_EXTERNAL = 0,
        /** retrieves all of the contours without establishing any hierarchical relationships. */
        RETR_LIST = 1,
        /** retrieves all of the contours and organizes them into a two-level hierarchy. At the top
        level, there are external boundaries of the components. At the second level, there are
        boundaries of the holes. If there is another contour inside a hole of a connected component, it
        is still put at the top level. */
        RETR_CCOMP = 2,
        /** retrieves all of the contours and reconstructs a full hierarchy of nested contours.*/
        RETR_TREE = 3,
        RETR_FLOODFILL = 4 //!<
    };
}
