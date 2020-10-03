using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnitTest
{
    public abstract class Test
    {
        protected string img3x5 = Path.GetFullPath("../../../../../data/3x5.jpg");
        protected string imgSolar = Path.GetFullPath("../../../../../data/solar.jpg");
        protected string mp4Road = Path.GetFullPath("../../../../../data/road.mp4");
        protected string UncorrectedImage = Path.GetFullPath("../../../../../data/UncorrectedImage.png");
        protected string SmoothImage = Path.GetFullPath("../../../../../data/SmoothImage.jpg");
        protected string MNIST_Image_5 = Path.GetFullPath("../../../../../data/mnist_image_5.npy");
    }
}
