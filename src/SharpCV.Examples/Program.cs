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
            var temp = cv2.imread(file);

            var img = cv2.imread(file);
            
            var cropped1 = cv2.imcrop(img, (150, 50, 200, 350));
            cv2.imwrite("cropped1.jpg", cropped1);
            var cropped2 = img[(50, 400), (150, 350)];
            cv2.imwrite("cropped2.jpg", cropped1);

            for (var i =0; i < 3; i++)
            {
                temp = cv2.pyrDown(temp);
                cv2.imshow("a", temp);
                cv2.waitKey(0);
            }
            
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
