using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransform
{
    internal class Program
    {
        // 단일 화소 양선형 보간 함수
        private static byte BilinearValue(Mat img, double x, double y)
        {
            // 주어진 좌표가 이미지의 경계를 넘어가지 않도록 보정합니다.
            if (x >= img.Cols - 1) x--;
            if (y >= img.Rows - 1) y--;

            // 주어진 좌표의 정수 부분을 기준으로 4개의 주변 픽셀 위치를 계산합니다.
            Point pt = new Point((int)x, (int)y);
            int A = img.At<byte>(pt.Y, pt.X);
            int B = img.At<byte>(pt.Y + 1, pt.X);
            int C = img.At<byte>(pt.Y, pt.X + 1);
            int D = img.At<byte>(pt.Y + 1, pt.X + 1);

            // 주어진 좌표와 기준 픽셀 사이의 상대적인 거리를 계산합니다.
            double alpha = y - pt.Y;
            double beta = x - pt.X;

            // 양선형 보간을 사용하여 결과 픽셀 값을 계산합니다.
            int P = A + (int)Math.Round(alpha * (B - A) + beta * (C - A + alpha * (D - B - C + A)));

            return (byte)P;
        }

        // 어파인 변환 함수
        private static void AffineTransform(Mat img, Mat dst, Mat map)
        {
            // 입력 이미지의 크기에 해당하는 사각형 영역을 정의합니다.
            Rect imgRect = new Rect(new Point(0, 0), img.Size());

            // 어파인 변환 매트릭스의 역행렬을 계산하여 invMap에 저장합니다.
            Mat invMap = new Mat();
            Cv2.InvertAffineTransform(map, invMap);

            // 결과 이미지의 모든 픽셀에 대해서
            for (int i = 0; i < dst.Rows; i++)
            {
                for (int j = 0; j < dst.Cols; j++)
                {
                    // 현재 픽셀의 위치를 3차원 포인트로 표현합니다. (옴니젠트 좌표 사용)
                    Point3d targetPoint = new Point3d(j, i, 1);

                    // 역변환을 통해 원본 이미지에서의 해당 픽셀 위치를 계산합니다.
                    Mat sourcePointMat = invMap * new Mat(3, 1, MatType.CV_64FC1, new double[] { targetPoint.X, targetPoint.Y, targetPoint.Z });
                    Point2d sourcePoint = new Point2d(sourcePointMat.At<double>(0), sourcePointMat.At<double>(1));

                    // 계산된 원본 이미지의 픽셀 위치가 유효한 범위 내에 있는지 확인합니다.
                    if (imgRect.Contains(sourcePoint.ToPoint()))
                        // 유효하면 양선형 보간을 통해 픽셀 값을 얻고 결과 이미지에 설정합니다.
                        dst.At<byte>(i, j) = BilinearValue(img, sourcePoint.X, sourcePoint.Y);
                }
            }
        }
        static void Main(string[] args)
        {
            Mat image = new Mat("C:\\Temp\\img\\affine_test3.jpg", ImreadModes.Grayscale);
            
            if (image.Empty())
                throw new Exception("이미지를 불러올 수 없습니다.");

            Point2f[] pt1 = { new Point2f(10, 200), new Point2f(200, 150), new Point2f(280, 280) };
            Point2f[] pt2 = { new Point2f(10, 10), new Point2f(250, 10), new Point2f(280, 280) };

            Point center = new Point(200, 100);
            double angle = 30.0;
            double scale = 1;

            Mat affMap = Cv2.GetAffineTransform(pt1, pt2);
            Mat rotMap = Cv2.GetRotationMatrix2D(center, angle, scale);

            Mat dst1 = new Mat(image.Size(), MatType.CV_8UC1);
            Mat dst2 = new Mat(image.Size(), MatType.CV_8UC1);
            Mat dst3 = new Mat(image.Size(), MatType.CV_8UC1);
            Mat dst4 = new Mat(image.Size(), MatType.CV_8UC1);

            AffineTransform(image, dst1, affMap);
            AffineTransform(image, dst2, rotMap);

            Cv2.WarpAffine(image, dst3, affMap, image.Size(), InterpolationFlags.Linear);
            Cv2.WarpAffine(image, dst4, rotMap, image.Size(), InterpolationFlags.Linear);

            Cv2.CvtColor(image, image, ColorConversionCodes.GRAY2BGR);
            Cv2.CvtColor(dst1, dst1, ColorConversionCodes.GRAY2BGR);

            Scalar color = new Scalar(0, 0, 255);
            for (int i = 0; i < 3; i++)
            {
                Cv2.Circle(image, (Point)pt1[i], 3, color, 2);
                Cv2.Circle(dst1, (Point)pt2[i], 3, color, 2);
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
