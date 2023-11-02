using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalingBilinear
{
    internal class Program
    {
        // 최근접 이웃 보간 함수
        static void ScalingNearest(Mat img, Mat dst, Size size)
        {
            dst.Create(size, MatType.CV_8U);
            dst.SetTo(0);

            double ratioY = (double)size.Height / img.Rows;
            double ratioX = (double)size.Width / img.Cols;

            for (int i = 0; i < dst.Rows; i++)
            {
                for (int j = 0; j < dst.Cols; j++)
                {
                    int x = (int)Math.Round(j / ratioX);
                    int y = (int)Math.Round(i / ratioY);
                    dst.At<byte>(i, j) = img.At<byte>(y, x);
                }
            }
        }

        // 단일 화소 양선형 보간 함수
        static byte BilinearValue(Mat img, double x, double y)
        {
            if (x >= img.Cols - 1) x--;
            if (y >= img.Rows - 1) y--;

            Point pt = new Point((int)x, (int)y);
            int A = img.At<byte>(pt.Y, pt.X); // 왼쪽 상단 화소
            int B = img.At<byte>(pt.Y + 1, pt.X); // 왼쪽 하단 화소
            int C = img.At<byte>(pt.Y, pt.X + 1); // 오른쪽 상단 화소
            int D = img.At<byte>(pt.Y + 1, pt.X + 1); // 오른쪽 하단 화소

            double alpha = y - pt.Y;
            double beta = x - pt.X;

            int M1 = A + (int)Math.Round(alpha * (B - A));
            int M2 = C + (int)Math.Round(alpha * (D - C));
            int P = M1 + (int)Math.Round(beta * (M2 - M1));

            return (byte)Math.Min(Math.Max(P, 0), 255);
        }

        // 양선형 보간을 사용한 크기 변경 함수
        static void ScalingBilinear(Mat img, Mat dst, Size size)
        {
            dst.Create(size, img.Type());
            dst.SetTo(0);

            double ratioY = (double)size.Height / img.Rows;
            double ratioX = (double)size.Width / img.Cols;

            for (int i = 0; i < dst.Rows; i++)
            {
                for (int j = 0; j < dst.Cols; j++)
                {
                    double y = i / ratioY;
                    double x = j / ratioX;
                    dst.At<byte>(i, j) = BilinearValue(img, x, y);
                }
            }
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead("C:\\Temp\\img\\interpolation_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
                throw new Exception("이미지를 불러올 수 없습니다.");

            Mat dst1 = new Mat();
            Mat dst2 = new Mat();
            Mat dst3 = new Mat();
            Mat dst4 = new Mat();

            ScalingBilinear(image, dst1, new Size(300, 300));   // 양선형 보간을 사용한 크기 변경
            ScalingNearest(image, dst2, new Size(300, 300));   // 최근접 이웃 보간을 사용한 크기 변경

            Cv2.Resize(image, dst3, new Size(300, 300), interpolation: InterpolationFlags.Linear);
            Cv2.Resize(image, dst4, new Size(300, 300), interpolation: InterpolationFlags.Nearest);

            Cv2.ImShow("image", image);
            Cv2.ImShow("dst1-양선형", dst1);
            Cv2.ImShow("dst2-최근접이웃", dst2);
            Cv2.ImShow("OpenCV-양선형", dst3);
            Cv2.ImShow("OpenCV-최근접이웃", dst4);

            Cv2.WaitKey();
        }
    }
}
