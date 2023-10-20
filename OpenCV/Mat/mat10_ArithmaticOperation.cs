using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmethicOperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat m1 = new Mat(3, 6, MatType.CV_8UC1, new Scalar(10));
            Mat m2 = new Mat(3, 6, MatType.CV_8UC1, new Scalar(50));
            Mat m_add1 = new Mat();
            Mat m_add2 = new Mat();
            Mat m_sub = new Mat();
            Mat m_div1 = new Mat();
            Mat m_div2 = new Mat();

            Mat mask = new Mat(m1.Size(), MatType.CV_8UC1, Scalar.All(0));
            Rect rect = new Rect(new Point(3, 0), new Size(3, 3));
            mask.SubMat(rect).SetTo(1);

            Cv2.Add(m1, m2, m_add1);
            Cv2.Add(m1, m2, m_add2, mask);

            Cv2.Divide(m1, m2, m_div1);
            m1.ConvertTo(m1, MatType.CV_32F);
            m2.ConvertTo(m2, MatType.CV_32F);
            Cv2.Divide(m1, m2, m_div2);

            Console.WriteLine("[m1] = ");
            Console.WriteLine(m1.Dump());
            Console.WriteLine("[m2] = ");
            Console.WriteLine(m2.Dump());
            Console.WriteLine("[mask] = ");
            Console.WriteLine(mask.Dump());
            Console.WriteLine("\n");
            Console.WriteLine("[m_add1] = ");
            Console.WriteLine(m_add1.Dump());
            Console.WriteLine("[m_add2] = ");
            Console.WriteLine(m_add2.Dump());
            Console.WriteLine("[m_div1] = ");
            Console.WriteLine(m_div1.Dump());
            Console.WriteLine("[m_div2] = ");
            Console.WriteLine(m_div2.Dump());
        }
    }
}
