using OpenCvSharp;
using System.Runtime.InteropServices;

namespace OpenCV_dotnet6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] data =
            {
                1.2, 2.3, 3.2,
                4.5, 5.0, 6.5
            };

            Mat m1 = new Mat(2, 3, MatType.CV_8U, new Scalar(0));
            Mat m2 = new Mat(2, 3, MatType.CV_8U, new Scalar(255));
            Mat m3 = new Mat(2, 3, MatType.CV_16S, new Scalar(300));
            Mat m4 = new Mat(2, 3, MatType.CV_32F);
            Marshal.Copy(data, 0, m4.Data, data.Length); ;

            Size sz = new Size(2, 3);
            Mat m5 = new Mat(sz, MatType.CV_64F, new Scalar(0));

            Console.WriteLine("m1 : \n" + m1.Dump());
            Console.WriteLine("m2 : \n" + m2.Dump());
            Console.WriteLine("m3 : \n" + m3.Dump());
            Console.WriteLine("m4 : \n" + m3.Dump());
            Console.WriteLine("m5 : \n" + m5.Dump());

            m1.Dispose();
            m2.Dispose();
            m3.Dispose();
            m4.Dispose();
            m5.Dispose();

        }
    }
}
