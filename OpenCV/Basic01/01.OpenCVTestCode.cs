using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVSharp001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"현재 OpenCV 버전 : {Cv2.GetVersionString()}");
        }
    }
}
