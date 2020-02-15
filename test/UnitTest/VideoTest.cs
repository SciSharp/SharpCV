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

        //[Ignore]
        [TestMethod]
        public void VideoCaptureFromCamera()
        {
            var vid = cv2.VideoCapture(0);
            var (loaded, frame) = vid.read();
            while (loaded)
            {
                (loaded, frame) = vid.read();
                cv2.imshow("camera capture", frame);
                cv2.waitKey(100);
            }
        }
    }
}
