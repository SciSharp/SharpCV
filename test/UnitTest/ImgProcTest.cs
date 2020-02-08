using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumSharp;
using SharpCV;
using System.IO;
using static SharpCV.Binding;

namespace UnitTest
{
    [TestClass]
    public class ImgProcTest : Test
    {
        [TestMethod]
        public void cvtColor()
        {
            var img = cv2.imread(imgSolar);
            var gray = cv2.cvtColor(img, ColorConversionCodes.COLOR_RGB2GRAY);
            Assert.AreEqual(299300, gray.size);
        }

        [TestMethod]
        public void threshold()
        {
            var img = cv2.imread(imgSolar);
            var gray = cv2.cvtColor(img, ColorConversionCodes.COLOR_RGB2GRAY);
            var (ret, binary) = cv2.threshold(gray, 0, 255, ThresholdTypes.THRESH_BINARY | ThresholdTypes.THRESH_TRIANGLE);
            Assert.AreEqual(299300, binary.size);
            // python version is 80.0
            Assert.AreEqual(81, ret);
        }

        [TestMethod]
        public void adaptiveThreshold()
        {
            var img = cv2.imread(imgSolar);
            var gray = cv2.cvtColor(img, ColorConversionCodes.COLOR_RGB2GRAY);
            var binary = cv2.adaptiveThreshold(gray, 255, AdaptiveThresholdTypes.ADAPTIVE_THRESH_GAUSSIAN_C, ThresholdTypes.THRESH_BINARY, 25, 10);
            Assert.AreEqual(299300, binary.size);
        }

        [TestMethod]
        public void pyrDown()
        {
            var img = cv2.imread(imgSolar);
            var dst = cv2.pyrDown(img);
        }

        [TestMethod]
        public void pyrUp()
        {
            var img = cv2.imread(imgSolar);
            var dst = cv2.pyrUp(img);
        }

        [TestMethod]
        public void resize()
        {
            var img = cv2.imread(imgSolar);
            var r = 200.0 / img.shape[1];
            var size = (200, (int)(img.shape[0] * r));
            var resized = cv2.resize(img, size, interpolation: InterpolationFlags.INTER_AREA);
            Assert.AreEqual(112, resized.shape[0]);
            Assert.AreEqual(200, resized.shape[1]);
            Assert.AreEqual(3, resized.shape[2]);
        }

        [TestMethod]
        public void rotate()
        {
            var img = cv2.imread(imgSolar);
            var rotated = cv2.rotate(img, (img.shape[1] / 2, img.shape[0] / 2), 180, 1.0);
            Assert.AreEqual(410, rotated.shape[0]);
            Assert.AreEqual(730, rotated.shape[1]);
            Assert.AreEqual(3, rotated.shape[2]);
        }

        [TestMethod]
        public void rectangle()
        {
            var img = cv2.imread(imgSolar);
            cv2.rectangle(img, (0, 0), (img.shape[1] / 2, img.shape[0] / 2), (255, 0, 0));
            cv2.imwrite("rectangle.jpg", img);
        }

        [TestMethod]
        public void minAreaRect()
        {
            var img = cv2.imread(imgSolar, IMREAD_COLOR.IMREAD_GRAYSCALE);
            var (ret, thresh) = cv2.threshold(img, 127, 255, 0);
            var (contours, hierarchy) = cv2.findContours(thresh, RetrievalModes.RETR_LIST, ContourApproximationModes.CHAIN_APPROX_SIMPLE);
            var cnt = contours[0];
            var rect = cv2.minAreaRect(cnt);
            Assert.AreEqual(-90, rect.Angle);
            Assert.AreEqual((1, 1), rect.Size);
            Assert.AreEqual((367.5f, 408.5f), rect.Center);
        }
    }
}
