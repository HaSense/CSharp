using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationTest
{
    internal class Program
    {
        static void Translation(Mat img, out Mat dst, Point pt) // 평행이동 함수
        {
            Rect rect = new Rect(new Point(0, 0), img.Size()); // 입력영상 범위 사각형
            dst = new Mat(img.Size(), img.Type(), new Scalar(0));

            for (int i = 0; i < dst.Rows; i++) // 목적영상 순회 - 역방향 사상
            {
                for (int j = 0; j < dst.Cols; j++)
                {
                    Point dstPt = new Point(j, i); // 목적영상 좌표
                    Point imgPt = dstPt - pt; // 입력영상 좌표
                    if (rect.Contains(imgPt)) // 입력영상 범위 확인
                    {
                        dst.Set(i, j, img.At<byte>(imgPt.Y, imgPt.X));
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"c:/Temp/opencv/translation_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                Console.WriteLine("Image load failed!");
                return;
            }

            Mat dst1, dst2;
            Translation(image, out dst1, new Point(30, 80)); // 평행이동 수행
            Translation(image, out dst2, new Point(-80, -50));

            Cv2.ImShow("image", image);
            Cv2.ImShow("dst1 - (30, 80) 이동", dst1);
            Cv2.ImShow("dst2 - (-80, -50) 이동", dst2);
            Cv2.WaitKey();
        }
    }
}
