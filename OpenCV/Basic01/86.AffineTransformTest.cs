using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformTest
{
    internal class Program
    {
        // 주어진 좌표 (x, y)에서 픽셀의 양선형 보간 값을 계산합니다.
        // 이 함수는 주변 네 개의 픽셀을 사용하여 그 사이의 값을 결정합니다.
        static byte BilinearValue(Mat img, double x, double y)
        {
            if (x >= img.Cols - 1) x--;
            if (y >= img.Rows - 1) y--;

            // 4개 화소 가져옴
            Point pt = new Point((int)x, (int)y);
            int A = img.At<byte>((int)pt.Y, (int)pt.X);
            int B = img.At<byte>((int)(pt.Y + 1), (int)pt.X);
            int C = img.At<byte>((int)pt.Y, (int)(pt.X + 1));
            int D = img.At<byte>((int)(pt.Y + 1), (int)(pt.X + 1));

            // 1차 보간
            double alpha = y - pt.Y;
            double beta = x - pt.X;
            int M1 = A + (int)Math.Round(alpha * (B - A));
            int M2 = C + (int)Math.Round(alpha * (D - C));

            // 2차 보간
            int P = M1 + (int)Math.Round(beta * (M2 - M1));
            return (byte)(P < 0 ? 0 : (P > 255 ? 255 : P));
        }

        // 주어진 변환 행렬을 사용하여 입력 이미지에 어파인 변환을 적용합니다.
        // 이 함수는 변환 행렬을 수동으로 반전하고, 양선형 보간법을 사용하여 출력 픽셀 값을 계산합니다.
        static void AffineTransform(Mat img, out Mat dst, Mat map)
        {
            dst = new Mat(img.Size(), img.Type(), Scalar.All(0));
            Rect rect = new Rect(new Point(0, 0), img.Size());

            Mat invMap = new Mat();
            Cv2.InvertAffineTransform(map, invMap);

            for (int i = 0; i < dst.Rows; i++)
            {
                for (int j = 0; j < dst.Cols; j++)
                {
                    Mat coordinateMatrix = new Mat(3, 1, MatType.CV_64F);
                    double[] values = { j, i, 1.0 };
                    for (int k = 0; k < 3; k++)
                    {
                        coordinateMatrix.Set(k, 0, values[k]);
                    }
                    Mat xy = invMap * coordinateMatrix;
                    Point2d pt = new Point2d(xy.At<double>(0), xy.At<double>(1));

                    if (rect.Contains(new Point((int)pt.X, (int)pt.Y)))
                    {
                        dst.Set(i, j, BilinearValue(img, pt.X, pt.Y));
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"C:/Temp/opencv/affine_test3.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                throw new Exception("Image not found!");
            }

            Point2f[] pt1 = { new Point2f(10, 200), new Point2f(200, 150), new Point2f(280, 280) };
            Point2f[] pt2 = { new Point2f(10, 10), new Point2f(250, 10), new Point2f(280, 280) };

            Point2f center = new Point2f(200, 100);
            double angle = 30.0;
            double scale = 1;

            Mat affMap = Cv2.GetAffineTransform(pt1, pt2);
            Mat rotMap = Cv2.GetRotationMatrix2D(center, angle, scale);

            Mat dst1, dst2, dst3 = new Mat(), dst4 = new Mat();
            AffineTransform(image, out dst1, affMap);
            AffineTransform(image, out dst2, rotMap);

            Cv2.WarpAffine(image, dst3, affMap, image.Size(), InterpolationFlags.Linear);
            Cv2.WarpAffine(image, dst4, rotMap, image.Size(), InterpolationFlags.Linear);

            Cv2.CvtColor(image, image, ColorConversionCodes.GRAY2BGR);
            Cv2.CvtColor(dst1, dst1, ColorConversionCodes.GRAY2BGR);

            for (int i = 0; i < 3; i++)
            {
                Cv2.Circle(image, (Point)pt1[i], 3, new Scalar(0, 0, 255), 2);
                Cv2.Circle(dst1, (Point)pt2[i], 3, new Scalar(0, 0, 255), 2);
            }

            Cv2.ImShow("image", image);
            Cv2.ImShow("dst1-어파인", dst1);
            Cv2.ImShow("dst2-어파인 회전", dst2);
            Cv2.ImShow("dst3-어파인_OpenCV", dst3);
            Cv2.ImShow("dst4-어파인-회전_OpenCV", dst4);

            Cv2.WaitKey();
        }
    }
}
