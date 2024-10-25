using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilinearScaling
{
    internal class Program
    {
        static void ScalingNearest(Mat img, out Mat dst, Size size) // 최근접 이웃 보간
        {
            dst = new Mat(size, MatType.CV_8U, new Scalar(0));
            double ratioY = (double)size.Height / img.Rows;
            double ratioX = (double)size.Width / img.Cols;

            for (int i = 0; i < dst.Rows; i++) // 목적영상 순회 - 역방향 사상
            {
                for (int j = 0; j < dst.Cols; j++)
                {
                    int x = (int)Math.Round(j / ratioX);
                    int y = (int)Math.Round(i / ratioY);
                    dst.Set(i, j, img.At<byte>(y, x));
                }
            }
        }

        static byte BilinearValue(Mat img, double x, double y) // 단일 화소 양선형 보간
        {
            if (x >= img.Cols - 1) x--;
            if (y >= img.Rows - 1) y--;

            Point pt = new Point((int)x, (int)y);
            byte A = img.At<byte>(pt.Y, pt.X);                       // 왼쪽상단 화소
            byte B = img.At<byte>(pt.Y + 1, pt.X);     // 왼쪽하단 화소
            byte C = img.At<byte>(pt.Y, pt.X + 1);     // 오른쪽상단 화소
            byte D = img.At<byte>(pt.Y + 1, pt.X + 1);     // 오른쪽하단 화소

            double alpha = y - pt.Y;
            double beta = x - pt.X;
            int M1 = A + (int)Math.Round(alpha * (B - A));  // 1차 보간
            int M2 = C + (int)Math.Round(alpha * (D - C));
            int P = M1 + (int)Math.Round(beta * (M2 - M1)); // 2차 보간

            return (byte)(P < 0 ? 0 : (P > 255 ? 255 : P));
        }

        static void ScalingBilinear(Mat img, out Mat dst, Size size) // 크기변경 – 양선형 보간
        {
            dst = new Mat(size, img.Type(), new Scalar(0));
            double ratioY = (double)size.Height / img.Rows;
            double ratioX = (double)size.Width / img.Cols;

            for (int i = 0; i < dst.Rows; i++) // 목적영상 순회 - 역방향 사상
            {
                for (int j = 0; j < dst.Cols; j++)
                {
                    double y = i / ratioY;
                    double x = j / ratioX;
                    dst.Set(i, j, BilinearValue(img, x, y)); // 화소 양선형 보간
                }
            }
        }

        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"c:/Temp/opencv/interpolation_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                Console.WriteLine("Image load failed!");
                return;
            }

            Mat dst1 = new Mat();
            Mat dst2 = new Mat();
            Mat dst3 = new Mat();
            Mat dst4 = new Mat();
            ScalingBilinear(image, out dst1, new Size(300, 300)); // 크기변경 – 양선형 보간
            ScalingNearest(image, out dst2, new Size(300, 300));  // 크기변경 – 최근접 보간
            Cv2.Resize(image, dst3, new Size(300, 300), 0, 0, InterpolationFlags.Linear); // OpenCV 함수 적용 - 양선형 보간
            Cv2.Resize(image, dst4, new Size(300, 300), 0, 0, InterpolationFlags.Nearest); // OpenCV 함수 적용 - 최근접 보간

            Cv2.ImShow("image", image);
            Cv2.ImShow("dst1-양선형", dst1);
            Cv2.ImShow("dst2-최근접이웃", dst2);
            Cv2.ImShow("OpenCV-양선형", dst3);
            Cv2.ImShow("OpenCV-최근접이웃", dst4);

            Cv2.WaitKey();
        }
    }
}
