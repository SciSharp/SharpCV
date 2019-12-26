using System;
using System.Collections.Generic;
using System.Text;

namespace SharpCV
{
    public static partial class Binding
    {
        public static cv_api cv2 { get; } = new cv_api();
    }
}
