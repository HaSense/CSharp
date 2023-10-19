using OpenCvSharp;
using System;
using System.Collections.Generic;

namespace OpenCVSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat ch0 = new Mat(3, 4, MatType.CV_8U, new Scalar(10));
            Mat ch1 = new Mat(3, 4, MatType.CV_8U, new Scalar(20));
            Mat ch2 = new Mat(3, 4, MatType.CV_8U, new Scalar(30));

            Mat[] bgr_arr = { ch0, ch1, ch2 };
            Mat bgr = new Mat();
            Cv2.Merge(bgr_arr, bgr);

            Mat[] bgr_vec = Cv2.Split(bgr);

            Console.WriteLine("[ch0] = \n" + ch0.Dump());
            Console.WriteLine("[ch1] = \n" + ch1.Dump());
            Console.WriteLine("[ch2] = \n" + ch2.Dump() + "\n");

            Console.WriteLine("[bgr] = \n" + bgr.Dump() + "\n");
            Console.WriteLine("[bgr_vec[0]] = \n" + bgr_vec[0].Dump());
            Console.WriteLine("[bgr_vec[1]] = \n" + bgr_vec[1].Dump());
            Console.WriteLine("[bgr_vec[2]] = \n" + bgr_vec[2].Dump());
        }
    }
}
