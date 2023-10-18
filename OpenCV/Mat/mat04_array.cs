using OpenCvSharp;
using System;

namespace OpenCvSharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[3, 3];

            int cnt = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr[j, i] = cnt++;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            Mat m2 = new Mat(3, 3, MatType.CV_32S, new int[] { 1, 4, 7, 2, 5, 8, 3, 6, 9 });
            Console.WriteLine("m2 : \n" + m2.Dump());

            m2.Dispose();
        }
    }
}
