using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationApp
{
    internal class Program
    {
        // 평행이동 함수
        static void Translation(Mat img, Mat dst, Point pt)
        {
            Rect rect = new Rect(new Point(0, 0), img.Size());
            img.CopyTo(dst);

            for (int i = 0; i < dst.Rows; i++)
            {
                for (int j = 0; j < dst.Cols; j++)
                {
                    Point dstPt = new Point(j, i);         // 목적영상 좌표
                    Point imgPt = dstPt - pt;              // 입력영상 좌표

                    if (rect.Contains(imgPt))              // 입력영상 범위 확인
                        dst.At<byte>(i, j) = img.At<byte>(imgPt.Y, imgPt.X);
                    else
                        dst.At<byte>(i, j) = 0;
                }
            }
        }
        static void Main(string[] args)
        {
            Mat image = new Mat("C:\\Temp\\img\\translation_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
                throw new Exception("이미지를 불러올 수 없습니다.");

            Mat dst1 = new Mat();
            Mat dst2 = new Mat();

            // 평행이동 수행
            Translation(image, dst1, new Point(30, 80));
            Translation(image, dst2, new Point(-80, -50));

            Cv2.ImShow("image", image);
            Cv2.ImShow("dst1 - (30, 80) 이동", dst1);
            Cv2.ImShow("dst2 - (-80, -50) 이동", dst2);

            Cv2.WaitKey();
        }
    }
}
