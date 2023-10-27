using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SobelEdge
{
    internal class Program
    {
        static void Differential(Mat image, Mat dst, float[] data1, float[] data2)
        {
            Mat dst1 = new Mat();
            Mat dst2 = new Mat();

            Mat mask1 = new Mat(3, 3, MatType.CV_32F, data1);
            Mat mask2 = new Mat(3, 3, MatType.CV_32F, data2);

            Cv2.Filter2D(image, dst1, MatType.CV_32F, mask1);   // OpenCV 제공 회선 함수
            Cv2.Filter2D(image, dst2, MatType.CV_32F, mask2);
            Cv2.Magnitude(dst1, dst2, dst);
            dst.ConvertTo(dst, MatType.CV_8U);

            dst1.ConvertTo(dst1, MatType.CV_8U, 1, 0);  // 절대값 및 형변환
            dst2.ConvertTo(dst2, MatType.CV_8U, 1, 0);  // 절대값 및 형변환

            Cv2.ImShow("dst1 - 수직 마스크", dst1);
            Cv2.ImShow("dst2 - 수평 마스크", dst2);
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead("C:\\Temp\\img\\edge_test1.jpg", ImreadModes.Grayscale);

            if (image.Empty())
            {
                Console.WriteLine("이미지를 불러올 수 없습니다.");
                return;
            }

            float[] data1 = {
                -1, 0, 1,
                -2, 0, 2,
                -1, 0, 1
            };

            float[] data2 = {
                -1, -2, -1,
                0, 0, 0,
                1, 2, 1
            };

            Mat dst = new Mat();
            Mat dst3 = new Mat();
            Mat dst4 = new Mat();
            Differential(image, dst, data1, data2);  // 두 방향 소벨 회선 및 크기 계산

            // OpenCV 제공 소벨 에지 계산
            Cv2.Sobel(image, dst3, MatType.CV_32F, 1, 0, 3);
            Cv2.Sobel(image, dst4, MatType.CV_32F, 0, 1, 3);
            dst3.ConvertTo(dst3, MatType.CV_8U, 1, 0);  // 절대값 및 형변환
            dst4.ConvertTo(dst4, MatType.CV_8U, 1, 0);

            Cv2.ImShow("image", image);
            Cv2.ImShow("소벨에지", dst);
            Cv2.ImShow("dst3-수직_OpenCV", dst3);
            Cv2.ImShow("dst4-수평_OpenCV", dst4);

            Cv2.WaitKey();
        }
    }
}
