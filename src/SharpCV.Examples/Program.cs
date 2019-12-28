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

            for(var i =0; i < 3; i++)
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
