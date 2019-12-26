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
        public void rotate()
        {
            var img = cv2.imread(imgSolar);
            var rotated = cv2.rotate(img, RotateFlags.ROTATE_90_CLOCKWISE);
            Assert.AreEqual(730, rotated.shape[0]);
            Assert.AreEqual(410, rotated.shape[1]);
            Assert.AreEqual(3, rotated.shape[2]);
        }
    }
}
