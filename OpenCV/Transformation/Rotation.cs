using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotation
{
    internal class Program
    {
        // 단일 화소 양선형 보간
        static byte BilinearValue(Mat img, double x, double y)
        {
            if (x >= img.Cols - 1) x--;
            if (y >= img.Rows - 1) y--;

            // 4개 화소 가져옴
            Point pt = new Point((int)x, (int)y);
            int A = img.At<byte>(pt.Y, pt.X);
            int B = img.At<byte>(pt.Y + 1, pt.X);
            int C = img.At<byte>(pt.Y, pt.X + 1);
            int D = img.At<byte>(pt.Y + 1, pt.X + 1);

            // 1차 보간
            double alpha = y - pt.Y;
            double beta = x - pt.X;
            int M1 = A + (int)Math.Round(alpha * (B - A));
            int M2 = C + (int)Math.Round(alpha * (D - C));

            // 2차 보간
            int P = M1 + (int)Math.Round(beta * (M2 - M1));
            return (byte)P;
        }

        // 회전 변환 함수
        static void Rotation(Mat img, Mat dst, double degree)
        {
            double radian = degree / 180 * Math.PI;
            double sinValue = Math.Sin(radian);
            double cosValue = Math.Cos(radian);

            for (int i = 0; i < dst.Rows; i++)
            {
                for (int j = 0; j < dst.Cols; j++)
                {
                    double x = j * cosValue + i * sinValue;
                    double y = -j * sinValue + i * cosValue;

                    if (x >= 0 && x < img.Cols && y >= 0 && y < img.Rows)
                        dst.At<byte>(i, j) = BilinearValue(img, x, y);
                }
            }
        }

        // pt 좌표 기준 회전 변환 함수
        static void Rotation(Mat img, Mat dst, double degree, Point pt)
        {
            double radian = degree / 180 * Math.PI;
            double sinValue = Math.Sin(radian);
            double cosValue = Math.Cos(radian);

            for (int i = 0; i < dst.Rows; i++)
            {
                for (int j = 0; j < dst.Cols; j++)
                {
                    int jj = j - pt.X;
                    int ii = i - pt.Y;
                    double x = jj * cosValue + ii * sinValue + pt.X;
                    double y = -jj * sinValue + ii * cosValue + pt.Y;

                    if (x >= 0 && x < img.Cols && y >= 0 && y < img.Rows)
                        dst.At<byte>(i, j) = BilinearValue(img, x, y);
                }
            }
        }
        static void Main(string[] args)
        {
            Mat image = new Mat("C:\\Temp\\img\\rotate_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
                throw new Exception("이미지를 불러올 수 없습니다.");

            Mat dst1 = new Mat(image.Size(), MatType.CV_8UC1);
            Mat dst2 = new Mat(image.Size(), MatType.CV_8UC1);

            Point center = new Point(image.Width / 2, image.Height / 2);

            Rotation(image, dst1, 20);
            Rotation(image, dst2, 20, center);

            Cv2.ImShow("image", image);
            Cv2.ImShow("dst1-20도 회전(원점)", dst1);
            Cv2.ImShow("dst2-20도 회전(중심점)", dst2);

            Cv2.WaitKey();
        }
    }
}
