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

        public void namedWindow(string name, WindowFlags mode)
        {
            cv2_native_api.highgui_namedWindow(name, (int)mode);
        }

        public void resizeWindow(string name, int width, int height)
        {
            cv2_native_api.highgui_resizeWindow(name, width, height);
        }

        public void waitKey(int delay)
        {
            cv2_native_api.highgui_waitKey(delay, out var output);
        }

        public void destroyAllWindows()
        {
            cv2_native_api.highgui_destroyAllWindows();
        }
    }
}
