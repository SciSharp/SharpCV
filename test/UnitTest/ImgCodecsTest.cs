using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using static SharpCV.Binding;

namespace UnitTest
{
    [TestClass]
    public class ImgCodecsTest : Test
    {
        [TestMethod]
        public void imread()
        {
            var img = cv2.imread(imgSolar);
            Assert.AreEqual(897900, img.size);
            Assert.AreEqual((410, 730, 3), img.shape);
        }

        [TestMethod]
        public void imwrite()
        {
            var img = cv2.imread(imgSolar);
            var result = cv2.imwrite("solar.jpg", img);
            Assert.IsTrue(result);
        }

        [Ignore]
        [TestMethod]
        public void imcrop()
        {
            var img = cv2.imread(imgSolar);
            var cropped = cv2.imcrop(img, (1, 3), (1, 3));
            cv2.imwrite("cropped.jpg", cropped);
        }
    }
}
