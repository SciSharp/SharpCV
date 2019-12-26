using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCV;
using System.IO;
using static SharpCV.Binding;

namespace UnitTest
{
    [TestClass]
    public class VideoTest : Test
    {
        [TestMethod]
        public void VideoCaptureFromFile()
        {
            int frameCnt = 0;
            Mat lastFrame = null;
            var vid = cv2.VideoCapture(mp4Road);
            var (loaded, frame) = vid.read();
            while (loaded)
            {
                frameCnt++;
                lastFrame = frame;
                (loaded, frame) = vid.read();
            }
            Assert.AreEqual(31, frameCnt);
            Assert.AreEqual(720, lastFrame.shape[0]);
            Assert.AreEqual(1280, lastFrame.shape[1]);
            Assert.AreEqual(3, lastFrame.shape[2]);
        }
    }
}
