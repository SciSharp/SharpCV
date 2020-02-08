using SharpCV;
using System;
using System.IO;
using static SharpCV.Binding;

namespace AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataDir = Path.GetFullPath("../../../../../data");
            /*string file = Path.GetFullPath("/solar.jpg");
            var temp = cv2.imread(file);

            var img = cv2.imread(file);
            
            var cropped1 = cv2.imcrop(img, (150, 50, 200, 350));
            cv2.imwrite("cropped1.jpg", cropped1);
            var cropped2 = img[(50, 400), (150, 350)];
            cv2.imwrite("cropped2.jpg", cropped2);*/

            // remove border
            var image = cv2.imread(Path.Combine(dataDir, "invoice.jpg"));
            var gray = cv2.cvtColor(image, ColorConversionCodes.COLOR_BGR2GRAY);
            var (_, thresh) = cv2.threshold(gray, 0, 255, ThresholdTypes.THRESH_BINARY_INV | ThresholdTypes.THRESH_OTSU);

            // Remove horizontal lines
            var horizontal_kernel = cv2.getStructuringElement(MorphShapes.MORPH_RECT, (20, 1));
            var remove_horizontal = cv2.morphologyEx(thresh, MorphTypes.MORPH_OPEN, horizontal_kernel, iterations: 2);
            var cnts  = cv2.findContoursAsPoints(remove_horizontal, RetrievalModes.RETR_EXTERNAL, ContourApproximationModes.CHAIN_APPROX_SIMPLE);
            foreach (var c in cnts)
                cv2.drawContours(image, new[] { c }, -1, (255, 255, 255), 5);

            // remove vertical border
            var vertical_kernel = cv2.getStructuringElement(MorphShapes.MORPH_RECT, (1, 20));
            var remove_vertical = cv2.morphologyEx(thresh, MorphTypes.MORPH_OPEN, vertical_kernel, iterations: 2);
            cnts = cv2.findContoursAsPoints(remove_vertical, RetrievalModes.RETR_EXTERNAL, ContourApproximationModes.CHAIN_APPROX_SIMPLE);
            foreach (var c in cnts)
                cv2.drawContours(image, new[] { c }, -1, (255, 255, 255), 5);

            cv2.imwrite("result-sharpcv.png", image);

            /*for (var i =0; i < 3; i++)
            {
                temp = cv2.pyrDown(temp);
                cv2.imshow("a", temp);
                cv2.waitKey(0);
            }*/

            // GC will dispose automatically
            /*for (int i = 0; i < 10000; i++)
            {
                using var img = cv2.imread(file);
            }*/

            Console.WriteLine("Completed");
            Console.ReadLine();
        }
    }
}
