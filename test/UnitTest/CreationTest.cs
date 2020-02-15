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
        public void ndarray()
        {
            NDArray kernel = new float[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            var mat = new Mat(kernel);

            Assert.AreEqual((3, 3), mat.shape);
            Assert.AreEqual(kernel[0], mat.data[0]);
            Assert.AreEqual(kernel[1], mat.data[1]);
            Assert.AreEqual(kernel[2], mat.data[2]);
        }
    }
}
