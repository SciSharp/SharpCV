using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnitTest
{
    public abstract class Test
    {
        protected string imgSolar = Path.GetFullPath("../../../../../data/solar.jpg");
        protected string mp4Road = Path.GetFullPath("../../../../../data/road.mp4");
        protected string UncorrectedImage = Path.GetFullPath("../../../../../data/UncorrectedImage.png");
        protected string SmoothImage = Path.GetFullPath("../../../../../data/SmoothImage.jpg");

    }
}
