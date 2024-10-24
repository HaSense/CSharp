using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoGEdge
{
    internal class Program
    {
        static Mat GetLoGMask(Size size, double sigma)
        {
            double ratio = 1 / (Math.PI * Math.Pow(sigma, 4.0));
            int center = size.Height / 2;
            Mat dst = new Mat(size, MatType.CV_64F);

            for (int i = 0; i < size.Height; i++)
            {
                for (int j = 0; j < size.Width; j++)
                {
                    int x2 = (j - center) * (j - center);
                    int y2 = (i - center) * (i - center);

                    double value = (x2 + y2) / (2 * sigma * sigma);
                    dst.Set(i, j, -ratio * (1 - value) * Math.Exp(-value));
                }
            }

            double scale = (center * 10 / ratio);
            dst *= scale;
            return dst;
        }
        static void Main(string[] args)
        {
            string path = @"C:/Temp/opencv/laplacian_test.jpg";
            Mat image = Cv2.ImRead(path, ImreadModes.Grayscale);

            if (image.Empty())
                throw new Exception("Failed to load image");

            //sigma값이 작으면 필터는 더 날카로워지고 커지면 더 부드럽게 되어 넓은 영역을 흐리게 함 
            double sigma = 1.4;
            Mat logMask = GetLoGMask(new Size(9, 9), sigma);

            Console.WriteLine(logMask);
            Console.WriteLine(Cv2.Sum(logMask));

            Mat dst1 = new Mat();
            Mat dst2 = new Mat();
            Mat gausImg = new Mat();

            // LoG 필터 적용
            Cv2.Filter2D(image, dst1, MatType.CV_32F, logMask);
            Cv2.GaussianBlur(image, gausImg, new Size(9, 9), sigma, sigma);
            Cv2.Laplacian(gausImg, dst2, MatType.CV_32F, 5);

            // DoG 계산
            Mat dst3 = new Mat();
            Mat dst4 = new Mat();
            Cv2.GaussianBlur(image, dst3, new Size(1, 1), 0.0);
            Cv2.GaussianBlur(image, dst4, new Size(9, 9), 1.6);
            Mat dstDoG = new Mat();
            Cv2.Subtract(dst3, dst4, dstDoG);

            Cv2.Normalize(dstDoG, dstDoG, 0, 255, NormTypes.MinMax);

            // 결과 출력
            Cv2.ImShow("image", image);
            Cv2.ImShow("dst1 - LoG_filter2D", dst1);
            Cv2.ImShow("dst2 - LOG_OpenCV", dst2);
            Cv2.ImShow("dst_DoG - DOG_OpenCV", dstDoG);
            Cv2.WaitKey();
        }
    }
}
