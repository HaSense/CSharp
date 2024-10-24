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
        static void Differential(Mat image, out Mat dst, float[] data1, float[] data2)
        {
            Mat mask1 = new Mat(3, 3, MatType.CV_32F);
            Mat mask2 = new Mat(3, 3, MatType.CV_32F);

            // data1 값을 mask1에 설정
            for (int i = 0; i < mask1.Rows; i++)
            {
                for (int j = 0; j < mask1.Cols; j++)
                {
                    mask1.Set<float>(i, j, data1[i * mask1.Cols + j]);
                }
            }

            // data2 값을 mask2에 설정
            for (int i = 0; i < mask2.Rows; i++)
            {
                for (int j = 0; j < mask2.Cols; j++)
                {
                    mask2.Set<float>(i, j, data2[i * mask2.Cols + j]);
                }
            }

            Mat dst1 = new Mat();
            Mat dst2 = new Mat();
            dst = new Mat();

            Cv2.Filter2D(image, dst1, MatType.CV_32F, mask1);  // OpenCV 제공 회선 함수
            Cv2.Filter2D(image, dst2, MatType.CV_32F, mask2);
            Cv2.Magnitude(dst1, dst2, dst);
            dst.ConvertTo(dst, MatType.CV_8U);

            Cv2.ConvertScaleAbs(dst1, dst1);  // 절대값 및 형변환 동시 수행 함수
            Cv2.ConvertScaleAbs(dst2, dst2);
            Cv2.ImShow("dst1 - 수직 마스크", dst1);
            Cv2.ImShow("dst2 - 수평 마스크", dst2);
        }
        static void Main(string[] args)
        {
            string path = @"C:/Temp/opencv/edge_test1.jpg";
            Mat image = Cv2.ImRead(path, ImreadModes.Grayscale);

            if (image.Empty())
                throw new Exception("Failed to load image");

            float[] data1 =
            {
                -1, 0, 1,
                -2, 0, 2,
                -1, 0, 1
            };
            float[] data2 =
            {
                -1, -2, -1,
                0, 0, 0,
                1, 2, 1
            };

            Mat dst;
            Differential(image, out dst, data1, data2);  // 두 방향 소벨 회선 및 크기 계산

            // OpenCV 제공 소벨 에지 계산
            Mat dst3 = new Mat();
            Mat dst4 = new Mat();

            Cv2.Sobel(image, dst3, MatType.CV_32F, 1, 0, 3);  // x방향 미분 - 수직 마스크
            Cv2.Sobel(image, dst4, MatType.CV_32F, 0, 1, 3);  // y방향 미분 - 수평 마스크
            Cv2.ConvertScaleAbs(dst3, dst3);  // 절대값 및 uchar 형변환
            Cv2.ConvertScaleAbs(dst4, dst4);

            Cv2.ImShow("image", image);
            Cv2.ImShow("소벨에지", dst);
            Cv2.ImShow("dst3-수직_OpenCV", dst3);
            Cv2.ImShow("dst4-수평_OpenCV", dst4);

            Cv2.WaitKey();
        }
    }
}
