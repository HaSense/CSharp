using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVSharp003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat m1 = new Mat(300, 400, MatType.CV_8UC1, new Scalar(200));
            
            Cv2.ImShow("m1표현", m1);

            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
