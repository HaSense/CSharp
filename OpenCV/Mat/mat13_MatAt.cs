using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatAt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat m1 = new Mat(3, 5, MatType.CV_32SC1);
            Mat m2 = new Mat(3, 5, MatType.CV_32FC1);
            Mat m3 = new Mat(3, 5, MatType.CV_8UC2);
            Mat m4 = new Mat(3, 5, MatType.CV_32SC3);

            for (int i = 0, k = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++, k++)
                {
                    m1.At<int>(i, j) = k;
                    m2.At<float>(i, j) = (float)j;
                    m3.At<Vec2b>(i, j) = new Vec2b(0, 1);

                    m4.At<Vec3i>(i, j) = new Vec3i(0, 1, 2);
                }
            }

            Console.WriteLine("[m1] = ");
            Console.WriteLine(m1.Dump());
            Console.WriteLine("[m2] = ");
            Console.WriteLine(m2.Dump());
            Console.WriteLine("[m3] = ");
            Console.WriteLine(m3.Dump());
            Console.WriteLine("[m4] = ");
            Console.WriteLine(m4.Dump());
        }
    }
}
