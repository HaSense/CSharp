using OpenCvSharp;
using System;

namespace OpenCvSharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] data = {
                1.2f, 2.3f, 3.2f,
                4.5f, 5.0f, 6.5f
            };

            Mat m1 = new Mat(2, 3, MatType.CV_8U);
            Mat m2 = new Mat(2, 3, MatType.CV_8U, new Scalar(300));
            Mat m3 = new Mat(2, 3, MatType.CV_16S, new Scalar(300));
            Mat m4 = new Mat(2, 3, MatType.CV_32F, data);

            Size sz = new Size(3, 2);
            Mat m5 = new Mat(sz, MatType.CV_64F);
            Mat m6 = new Mat(sz, MatType.CV_32F, data);

            Console.WriteLine("m1 : \n" + m1.Dump());
            Console.WriteLine("m2 : \n" + m2.Dump());
            Console.WriteLine("m3 : \n" + m3.Dump());
            Console.WriteLine("m4 : \n" + m4.Dump());
            Console.WriteLine("m5 : \n" + m5.Dump());
            Console.WriteLine("m6 : \n" + m6.Dump());

            m1.Dispose();
            m2.Dispose();
            m3.Dispose();
            m4.Dispose();
            m5.Dispose();
            m6.Dispose();
        }
    }
}
