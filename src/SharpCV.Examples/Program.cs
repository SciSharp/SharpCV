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
            string file = Path.GetFullPath("../../../../../data/solar.jpg");

            BlackWhite(file);

            // GC will dispose automatically
            /*for (int i = 0; i < 10000; i++)
            {
                using var img = cv2.imread(file);
            }*/

            Console.WriteLine("Completed");
            Console.ReadLine();
        }

        private static void BlackWhite(string file)
        {
            var img = cv2.imread(file);
            var gray = cv2.cvtColor(img, ColorConversionCodes.COLOR_RGB2GRAY);
            var (ret, binary) = cv2.threshold(gray, 0, 255, ThresholdTypes.THRESH_BINARY | ThresholdTypes.THRESH_TRIANGLE);
            cv2.imshow("", binary);
            cv2.waitKey(0);
        }
    }
}
