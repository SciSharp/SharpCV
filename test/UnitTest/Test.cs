using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnitTest
{
    public abstract class Test
    {
        public string datadir = Path.GetFullPath("../../../../../../data");
        protected string img3x5;
        protected string imgSolar;
        protected string mp4Road;
        protected string UncorrectedImage;
        protected string SmoothImage;
        protected string MNIST_Image_5;
        public Test()
        {
            img3x5 = Path.Combine(datadir, "3x5.jpg");
            imgSolar = Path.Combine(datadir, "solar.jpg");
            mp4Road = Path.Combine(datadir, "road.mp4");
            UncorrectedImage = Path.Combine(datadir, "UncorrectedImage.png");
            SmoothImage = Path.Combine(datadir, "SmoothImage.jpg");
            MNIST_Image_5 = Path.Combine(datadir, "mnist_image_5.npy");
        }
    }
}
