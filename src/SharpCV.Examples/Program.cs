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
