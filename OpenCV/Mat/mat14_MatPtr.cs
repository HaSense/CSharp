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
            Mat m1 = new Mat(3, 5, MatType.CV_8UC1);
            Mat m2 = new Mat(m1.Size(), MatType.CV_32FC1);

            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Cols; j++)
                {
                    m1.At<byte>(i, j) = (byte)j;
                    m2.At<float>(i, j) = (float)j;
                }
            }

            Console.WriteLine("m1 = ");
            Console.WriteLine(m1.Dump());
            Console.WriteLine("m2 = ");
            Console.WriteLine(m2.Dump());
        }
    }
}
