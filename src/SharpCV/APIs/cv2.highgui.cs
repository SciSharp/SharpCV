using NumSharp;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    public partial class cv_api
    {
        public void imshow(string windownName, Mat img)
        {
            cv2_native_api.highgui_imshow(windownName, img);
        }

        public void waitKey(int delay)
        {
            cv2_native_api.highgui_waitKey(delay, out var output);
        }
    }
}
