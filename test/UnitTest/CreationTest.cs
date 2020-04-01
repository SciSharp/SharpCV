using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumSharp;
using SharpCV;
using System;
using System.Collections.Generic;
using System.Text;
using static SharpCV.Binding;

namespace UnitTest
{
    [TestClass]
    public class CreationTest : Test
    {
        [TestMethod]
        public void ndarray_2dim_byte()
        {
            NDArray kernel = new byte[,]
            {
                { 172, 172, 173 },
                { 174, 174, 174 },
                { 175, 176, 173 }
            };

            var mat = new Mat(kernel);

            Assert.AreEqual((3, 3), mat.shape);
            Assert.AreEqual(kernel[0], mat.data[0]);
            Assert.AreEqual(kernel[1], mat.data[1]);
            Assert.AreEqual(kernel[2], mat.data[2]);
        }

        [TestMethod]
        public void ndarray_2dim_float()
        {
            NDArray kernel = new float[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { -2, -1, 3 }
            };

            var mat = new Mat(kernel);

            Assert.AreEqual((3, 3), mat.shape);
            Assert.AreEqual(kernel[0], mat.data[0]);
            Assert.AreEqual(kernel[1], mat.data[1]);
            Assert.AreEqual(kernel[2], mat.data[2]);
        }

        [TestMethod]
        public void ndarray_jagged_array_int()
        {
            NDArray kernel = new int[][]
            {
                new int[]{ 0, -1, 0 },
                new int[]{ -1, 5, -1 },
                new int[]{ -2, -1, 3 }
            };

            var mat = new Mat(kernel);

            Assert.AreEqual((3, 3), mat.shape);
            Assert.AreEqual(kernel[0], mat.data[0]);
            Assert.AreEqual(kernel[1], mat.data[1]);
            Assert.AreEqual(kernel[2], mat.data[2]);
        }

        [TestMethod]
        public void ndarray_mat_3x5()
        {
            var img = cv2.imread(img3x5);
            var nd = img.data[":,:,0"];
            var mat = new Mat(nd);

            Assert.AreEqual((5, 3), nd.Shape);
            Assert.AreEqual(nd[0], mat.data[0]);
            Assert.AreEqual(nd[1], mat.data[1]);
            Assert.AreEqual(nd[2], mat.data[2]);
        }
    }
}
