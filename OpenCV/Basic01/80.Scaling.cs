using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaling
{
    internal class Program
    {
        static void Scaling(Mat img, out Mat dst, Size size)
        {
            dst = new Mat(size, img.Type(), new Scalar(0));
            double ratioY = (double)size.Height / img.Rows; // 세로 변경 비율
            double ratioX = (double)size.Width / img.Cols;  // 가로 변경 비율

            for (int i = 0; i < img.Rows; i++) // 입력영상 순회 - 순방향 사상
            {
                for (int j = 0; j < img.Cols; j++)
                {
                    int x = (int)(j * ratioX);
                    int y = (int)(i * ratioY);
                    dst.Set(y, x, img.At<byte>(i, j));
                }
            }
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"c:/Temp/opencv/scaling_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                Console.WriteLine("Image load failed!");
                return;
            }

            Mat dst1, dst2;
            Scaling(image, out dst1, new Size(150, 200)); // 크기변경 수행 - 축소
            Scaling(image, out dst2, new Size(300, 400)); // 크기변경 수행 - 확대

            Cv2.ImShow("image", image);
            Cv2.ImShow("dst1-축소", dst1);
            Cv2.ImShow("dst2-확대", dst2);
            Cv2.ResizeWindow("dst1-축소", 200, 200); // 윈도우 크기 확장
            Cv2.WaitKey();
        }
    }
}
