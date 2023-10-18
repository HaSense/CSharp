using OpenCvSharp;
using System;

namespace OpenCvSharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 32.12345678, b = 2.7;
            short c = 400;
            float d = 10.0f, e = 11.0f, f = 13.0f;

            Mat m1 = new Mat(2, 4, MatType.CV_32S, new int[] { 1, 2, 3, 4, 5, 6, 0, 0 }); // Note: We need to fill in all elements
            Mat m2 = new Mat(3, 4, MatType.CV_8U, new Scalar(100));
            Mat m3 = new Mat(4, 5, MatType.CV_16S, new Scalar(c));

            Mat m4 = new Mat(2, 3, MatType.CV_64F, new double[] { 1, 2, 3, 4, 5, 6 });
            Mat m5 = new Mat(2, 3, MatType.CV_32F, new float[] { (float)a, (float)b, c, d, e, f });

            Console.WriteLine("m1 : \n" + m1.Dump());
            Console.WriteLine("m2 : \n" + m2.Dump());
            Console.WriteLine("m3 : \n" + m3.Dump());
            Console.WriteLine("m4 : \n" + m4.Dump());
            Console.WriteLine("m5 : \n" + m5.Dump());

            m1.Dispose();
            m2.Dispose();
            m3.Dispose();
            m4.Dispose();
            m5.Dispose();
        }
    }
}
