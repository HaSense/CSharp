using OpenCvSharp;
using System;

namespace OpenCvSharpSample
{
    class MatManager
    {
        public void ShowInfo(string name, Mat m)
        {
            string matType = FindType(m);
            Console.WriteLine($"{name} 크기 {m.Size()}, 자료형 {matType}C{m.Channels()}");
            Console.WriteLine(m.Dump());
            Console.WriteLine();
        }

        private string FindType(Mat m)
        {
            switch (m.Depth())
            {
                case MatType.CV_8U: return "CV_8U";
                case MatType.CV_8S: return "CV_8S";
                case MatType.CV_16U: return "CV_16U";
                case MatType.CV_32S: return "CV_32S";
                case MatType.CV_32F: return "CV_32F";
                case MatType.CV_64F: return "CV_64F";
                default: return "Unknown";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Mat m1 = new Mat();
            Mat m2 = new Mat();
            Mat m3 = new Mat();
            Mat m4 = new Mat(2, 6, MatType.CV_8UC1);
            Mat m5 = new Mat();

            Mat add1 = new Mat(2, 3, MatType.CV_8UC1, new Scalar(100));
            Mat add2 = Mat.Eye(4, 3, MatType.CV_8UC1);

            m1.PushBack(100);
            m1.PushBack(200);
            m2.PushBack(100.5);
            m2.PushBack(200.6);

            // m3.PushBack(add1); // This operation is not directly supported in OpenCvSharp
            // m3.PushBack(add2); // This operation is not directly supported in OpenCvSharp

            // m4.PushBack(add1); // This operation is not directly supported in OpenCvSharp
            // m4.PushBack(100);  // This operation is not directly supported in OpenCvSharp
            m4.PushBack(add1.Reshape(1, 1));
            m4.PushBack(add2.Reshape(1, 2));

            MatManager matManager = new MatManager();
            matManager.ShowInfo("m1", m1);
            matManager.ShowInfo("m2", m2);
            // matManager.ShowInfo("m3", m3); // Commented out since m3.PushBack() is not supported
            matManager.ShowInfo("m4", m4);
            // matManager.ShowInfo("m5", m5); // m5 is empty, so we're skipping this

            // Console.WriteLine($"m1 : \n{m1.Dump()}"); // This was commented out in the original code

            // m1.PopBack(2); // This operation is not directly supported in OpenCvSharp

            // Console.WriteLine($"m1 : \n{m1.Dump()}"); // This was commented out in the original code
        }
    }
}
