using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumSharp;
using SharpCV;
using System;
using static SharpCV.Binding;

namespace UnitTest
{
    [TestClass]
    public class OCRImageEnhance : Test
    {
        public Mat imread()
        {
            var img = cv2.imread(SmoothImage);
            var gray = cv2.cvtColor(img, ColorConversionCodes.COLOR_RGB2GRAY);
            return gray;
        }

        public void imwrite(Mat img)
        {
            var result = cv2.imwrite("EnhancedImage.jpg", img);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void enhanceImage()
        {
            Mat img = imread();

            NDArray filter1_kernel = np.array(new float[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } });
            Mat filter1 = cv2.filter2D(img, MatType.CV_8UC1, new Mat(filter1_kernel), new Point(-1, -1), 0);
            var open_kernel = cv2.getStructuringElement(MorphShapes.MORPH_RECT, (3, 3));
            var img_open = cv2.morphologyEx(filter1, MorphTypes.MORPH_OPEN, open_kernel, iterations: 1);
            // var img_median = cv2.medianBlur(img_open, 3);

            imwrite(img_open);
        }

    }
}
