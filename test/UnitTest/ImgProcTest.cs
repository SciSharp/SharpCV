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
    }
}
