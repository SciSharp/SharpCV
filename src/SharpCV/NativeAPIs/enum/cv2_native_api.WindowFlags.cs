using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    /// <summary>
    /// modules\highgui\include\opencv2\highgui.hpp
    /// </summary>
    public enum WindowFlags
    {
        WINDOW_NORMAL = 0x00000000, //!< the user can resize the window (no constraint) / also use to switch a fullscreen window to a normal size.
        WINDOW_AUTOSIZE = 0x00000001, //!< the user cannot resize the window, the size is constrainted by the image displayed.
        WINDOW_OPENGL = 0x00001000, //!< window with opengl support.

        WINDOW_FULLSCREEN = 1,          //!< change the window to fullscreen.
        WINDOW_FREERATIO = 0x00000100, //!< the image expends as much as it can (no ratio constraint).
        WINDOW_KEEPRATIO = 0x00000000, //!< the ratio of the image is respected.
        WINDOW_GUI_EXPANDED = 0x00000000, //!< status bar and tool bar
        WINDOW_GUI_NORMAL = 0x00000010, //!< old fashious way
    };
}
