using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVSharp004
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point pt1 = new Point(3, 4);
            Point2f pt2 = new Point2f(3.1f, 4.5f);
            Point3d pt3 = new Point3d(100, 200, 300);

            Mat m2 = new Mat(200, 300, MatType.CV_8U, new Scalar(200));

            Cv2.ImShow("m2", m2);

            Console.WriteLine($"pt1({pt1.X}, {pt1.Y})");
            Console.WriteLine($"pt2({pt2.X}, {pt2.Y})");
            Console.WriteLine($"pt3({pt3.X}, {pt3.Y}, {pt3.Z})");

            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
