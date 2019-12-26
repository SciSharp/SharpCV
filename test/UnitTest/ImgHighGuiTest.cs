using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using static SharpCV.Binding;

namespace UnitTest
{
    [TestClass]
    public class ImgHighGuiTest : Test
    {
        [TestMethod]
        public void imshow()
        {
            var img = cv2.imread(imgSolar);
            // cv2.imshow("solar", img);
            // cv2.waitKey(0);
        }
    }
}
