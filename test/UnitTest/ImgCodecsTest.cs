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

        [TestMethod]
        public void imcrop()
        {
            var img = cv2.imread(imgSolar);
            var cropped1 = cv2.imcrop(img, (150, 50, 200, 350));
            Assert.AreEqual((350, 200, 3), cropped1.shape);

            var cropped2 = img[(50, 400), (150, 350)];
            Assert.AreEqual((350, 200, 3), cropped2.shape);
        }
    }
}
