using OpenCvSharp;
using System;

namespace OpenCvSharpSample
{
    class CVInfo
    {
        public void PrintMatInfo(string m_name, Mat m)
        {
            Console.WriteLine($"[{m_name} 행렬]");
            Console.WriteLine($"   채널 수 = {m.Channels()}");
            Console.WriteLine($"   행 X 열 = {m.Rows} x {m.Cols}\n");
            Console.WriteLine($"행렬 :\n{m.Dump()}\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Mat m1 = new Mat(2, 6, MatType.CV_8U);
            Mat m2 = m1.Reshape(2, m1.Rows * m1.Cols);
            Mat m3 = m1.Reshape(3, 2);

            CVInfo cvinfo = new CVInfo();
            cvinfo.PrintMatInfo("m1(2, 6)", m1);
            cvinfo.PrintMatInfo("m2 = m1_reshape(2)", m2);
            cvinfo.PrintMatInfo("m3 = m1_reshape(3, 2)", m3);

            //m1.Create(3, 5, MatType.CV_16S);
            //cvinfo.PrintMatInfo("m1.create(3, 5)", m1);

            m1.Dispose();
            m2.Dispose();
            m3.Dispose();
        }
    }
}
