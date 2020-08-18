using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;
using static SharpCV.Binding;
using NumSharp;
using System.IO;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class CoreTest : Test
    {
        [TestMethod]
        public void pixel_getter()
        {
            // getter
            var img1 = cv2.imread(imgSolar);
            var (b, g, r) = img1[8, 8];
            Assert.AreEqual((32, 19, 11), (b, g, r));

            // access specific channel
            b = img1[8, 8, 0];
            g = img1[8, 8, 1];
            r = img1[8, 8, 2];
            Assert.AreEqual((32, 19, 11), (b, g, r));

            var img2 = cv2.imread(imgSolar, IMREAD_COLOR.IMREAD_GRAYSCALE);
            byte p = img2[8, 8];
            Assert.AreEqual(18, p);
        }

        [TestMethod]
        public void pixel_setter()
        {
            var img = cv2.imread(imgSolar);
            // img[8, 8] = (0, 0, 255);
        }

        [TestMethod]
        public void hconcat()
        {
            var img = cv2.imread(imgSolar);
            var hconcated = cv2.hconcat(img, img);
            Assert.AreEqual(410, hconcated.shape[0]);
            Assert.AreEqual(1460, hconcated.shape[1]);
            Assert.AreEqual(3, hconcated.shape[2]);
        }

        [TestMethod]
        public void vconcat()
        {
            var img = cv2.imread(imgSolar);
            var hconcated = cv2.vconcat(img, img);
            Assert.AreEqual(820, hconcated.shape[0]);
            Assert.AreEqual(730, hconcated.shape[1]);
            Assert.AreEqual(3, hconcated.shape[2]);
        }

        [TestMethod]
        public void rotate()
        {
            var img = cv2.imread(imgSolar);
            var rotated = cv2.rotate(img, RotateFlags.ROTATE_90_CLOCKWISE);
            Assert.AreEqual(730, rotated.shape[0]);
            Assert.AreEqual(410, rotated.shape[1]);
            Assert.AreEqual(3, rotated.shape[2]);
        }

        [TestMethod]
        public void flip()
        {
            var img = cv2.imread(imgSolar);
            var flipped = cv2.flip(img, FLIP_MODE.FLIP_HORIZONTAL_MODE);
            Assert.AreEqual(410, flipped.shape[0]);
            Assert.AreEqual(730, flipped.shape[1]);
            Assert.AreEqual(3, flipped.shape[2]);
        }

        [TestMethod]
        public void NDShow()
        {
            string path = Path.GetFullPath(@"..//..//..//") + "data//mnist_first_image_data.txt";
            var data = File.ReadLines(path);
            var listDouble = data.Select(Convert.ToDouble).ToArray();
            NDArray mnist_image1 = new NDArray(listDouble);
            mnist_image1 = mnist_image1.reshape(new int[] { 28, 28, 1 });
            cv2.imshow("NDShowTest", mnist_image1);
        }
    }
}
