using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVxor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat imageA = Cv2.ImRead(@"c:/Temp/pcb1.png", ImreadModes.Grayscale);
            Mat imageB = Cv2.ImRead(@"c:/Temp/pcb2.png", ImreadModes.Grayscale);

            if (imageA.Empty() || imageB.Empty())
            {
                Console.WriteLine("이미지를 불러올 수 없습니다. 경로를 확인하세요.");
                return;
            }

            Mat result = new Mat();

            Cv2.BitwiseXor(imageA, imageB, result);

            Cv2.ImShow("결과출력", result);

            Cv2.WaitKey(0);

            Cv2.DestroyAllWindows();
        }
    }
}
