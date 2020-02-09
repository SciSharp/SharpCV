using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCV;
using System;
using static SharpCV.Binding;


namespace UnitTest
{
    [TestClass]
    public class CorrectImageTest : Test
    {

        public Mat imread()
        {
            var img = cv2.imread(UncorrectedImage);
            //Assert.AreEqual(1760094, img.size);
            //Assert.AreEqual((854, 687, 3), img.shape);
            var gray = cv2.cvtColor(img, ColorConversionCodes.COLOR_RGB2GRAY);
            return gray;
        }

        public void imwrite(Mat img)
        {
            var result = cv2.imwrite("CorrectedImage.png", img);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void correctImage()
        {
            Mat img = imread();
            var angle = findAngle(img);
            Mat correctedImage = new Mat();
            (int, int) center = (img.shape[0] / 2, img.shape[1] / 2);
            correctedImage = cv2.rotate(img, center, angle, 1.0, InterpolationFlags.INTER_LINEAR, BorderTypes.BORDER_DEFAULT);
            imwrite(correctedImage);
        }

        public float findAngle(Mat img)
        {
            float angle = 0;
            var (_, thresh) = cv2.threshold(img, 0, 255, ThresholdTypes.THRESH_BINARY_INV | ThresholdTypes.THRESH_OTSU);
            var dilate_kernel = cv2.getStructuringElement(MorphShapes.MORPH_RECT, (3, 3));
            var dilate = cv2.morphologyEx(thresh, MorphTypes.MORPH_DILATE, dilate_kernel, iterations: 2);

            //var cnts = cv2.findContoursAsPoints(dilate, RetrievalModes.RETR_EXTERNAL, ContourApproximationModes.CHAIN_APPROX_NONE);
            //Point[] max_contour = new Point[] { };
            //foreach (var c in cnts)//TODO: use length filter here,but area filter is better
            //    if (c.Length > max_contour.Length) max_contour = c;
            var (cnts, _) = cv2.findContours(dilate, RetrievalModes.RETR_EXTERNAL, ContourApproximationModes.CHAIN_APPROX_NONE);
            Mat max_contour = new Mat();
            foreach (var c in cnts)//TODO: use length filter here,but area filter is better
                if (c.size > max_contour.size) max_contour = c;

            Mat contours_poly = cv2.approxPolyDP(max_contour, 30, true);
            RotatedRect rotatedRect = cv2.minAreaRect(contours_poly);
            angle = rotatedRect.Angle;
            if (Math.Abs(angle) > 45.0)
                angle = 90.0f + rotatedRect.Angle;

            //var color = cv2.cvtColor(img, ColorConversionCodes.COLOR_GRAY2RGB);
            //cv2.drawContours(color, new[] { max_contour }, -1, (255, 0, 0), 5);   
            //cv2.imwrite("test1.jpg", color); 

            return angle;
        }

    }
}
