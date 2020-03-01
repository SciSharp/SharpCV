using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;
using static SharpCV.Binding;

namespace UnitTest
{
    [TestClass]
    public class CoreTest : Test
    {
        [TestMethod]
        public void pixel()
        {
            var img1 = cv2.imread(imgSolar);
            var ndim = img1.ndim;
            var (b, g, r) = img1[8, 8];
            Assert.AreEqual((32, 19, 11), (b, g, r));

            var img2 = cv2.imread(imgSolar, IMREAD_COLOR.IMREAD_GRAYSCALE);
            byte p = img2[8, 8];
            Assert.AreEqual(18, p);
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
    }
}
