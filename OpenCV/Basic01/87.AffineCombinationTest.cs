using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineCombinationTest
{
    internal class Program
    {
        /// 주어진 좌표 (x, y)에서 픽셀의 양선형 보간 값을 계산합니다.
        /// 이 함수는 주변 네 개의 픽셀을 사용하여 그 사이의 값을 결정합니다.
        static byte BilinearValue(Mat img, double x, double y)
        {
            if (x >= img.Cols - 1) x--;
            if (y >= img.Rows - 1) y--;

            // 4개의 화소 값을 가져옴 (주변 픽셀)
            Point pt = new Point((int)x, (int)y);
            int A = img.At<byte>((int)pt.Y, (int)pt.X);
            int B = img.At<byte>((int)(pt.Y + 1), (int)pt.X);
            int C = img.At<byte>((int)pt.Y, (int)(pt.X + 1));
            int D = img.At<byte>((int)(pt.Y + 1), (int)(pt.X + 1));

            // 1차 보간 (가로 방향)
            double alpha = y - pt.Y;
            double beta = x - pt.X;
            int M1 = A + (int)Math.Round(alpha * (B - A));
            int M2 = C + (int)Math.Round(alpha * (D - C));

            // 2차 보간 (세로 방향)
            int P = M1 + (int)Math.Round(beta * (M2 - M1));
            return (byte)(P < 0 ? 0 : (P > 255 ? 255 : P)); // 범위를 0~255로 제한하여 반환
        }

        /// 주어진 변환 행렬을 사용하여 입력 이미지에 어파인 변환을 적용합니다.
        /// 이 함수는 변환 행렬을 수동으로 반전하고, 양선형 보간법을 사용하여 출력 픽셀 값을 계산합니다.
        static void AffineTransform(Mat img, out Mat dst, Mat map, Size size)
        {
            dst = new Mat(size, img.Type(), Scalar.All(0)); // 초기화된 출력 이미지 생성
            Rect rect = new Rect(new Point(0, 0), img.Size()); // 이미지 범위를 나타내는 직사각형 정의

            // 어파인 변환 행렬의 역변환 계산
            Mat invMap = new Mat();
            Cv2.InvertAffineTransform(map, invMap);

            for (int i = 0; i < size.Height; i++)
            {
                for (int j = 0; j < size.Width; j++)
                {
                    // 역변환 행렬을 사용하여 원본 이미지의 좌표 계산
                    Mat coordinateMatrix = new Mat(3, 1, MatType.CV_64F);
                    double[] values = { j, i, 1.0 };
                    for (int k = 0; k < 3; k++)
                    {
                        coordinateMatrix.Set(k, 0, values[k]);
                    }
                    Mat xy = invMap * coordinateMatrix;
                    Point2d pt = new Point2d(xy.At<double>(0), xy.At<double>(1));

                    // 계산된 좌표가 원본 이미지 내부에 있는 경우 보간 값을 설정
                    if (rect.Contains(new Point((int)pt.X, (int)pt.Y)))
                    {
                        dst.Set(i, j, BilinearValue(img, pt.X, pt.Y));
                    }
                }
            }
        }

        /// 어파인 변환 매핑을 생성하는 함수입니다.
        /// 회전, 스케일링, 평행이동 등을 포함합니다.
        static Mat GetAffineMap(Point2d center, double degree, double fx = 1, double fy = 1, Point2d translate = default)
        {
            // 회전 행렬, 중심 이동, 원점 이동, 스케일링, 평행 이동을 위한 행렬 초기화
            Mat rotMap = Mat.Eye(3, 3, MatType.CV_64F);
            Mat centerTrans = Mat.Eye(3, 3, MatType.CV_64F);
            Mat orgTrans = Mat.Eye(3, 3, MatType.CV_64F);
            Mat scaleMap = Mat.Eye(3, 3, MatType.CV_64F);
            Mat transMap = Mat.Eye(3, 3, MatType.CV_64F);

            // 회전 변환 정의
            double radian = degree / 180 * Math.PI;
            rotMap.Set(0, 0, Math.Cos(radian));
            rotMap.Set(0, 1, Math.Sin(radian));
            rotMap.Set(1, 0, -Math.Sin(radian));
            rotMap.Set(1, 1, Math.Cos(radian));

            // 중심 이동 변환
            centerTrans.Set(0, 2, center.X);
            centerTrans.Set(1, 2, center.Y);
            orgTrans.Set(0, 2, -center.X);
            orgTrans.Set(1, 2, -center.Y);

            // 스케일링 및 평행 이동 변환
            scaleMap.Set(0, 0, fx);
            scaleMap.Set(1, 1, fy);
            transMap.Set(0, 2, translate.X);
            transMap.Set(1, 2, translate.Y);

            // 최종 어파인 변환 행렬 계산
            Mat retMap = centerTrans * rotMap * transMap * scaleMap * orgTrans;
            retMap = retMap.RowRange(0, 2); // 2x3 변환 행렬로 반환
            return retMap;
        }

        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"c:/Temp/opencv/affine_test5.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                throw new Exception("Image not found!");
            }

            Point2f center = new Point2f(image.Width / 2, image.Height / 2);
            Point tr = new Point(100, 0);
            double angle = 30.0;
            Mat dst1 = new Mat();
            Mat dst2 = new Mat();
            Mat dst3 = new Mat();
            Mat dst4 = new Mat();

            // 어파인 변환 행렬을 생성
            Point2d centerD = new Point2d(center.X, center.Y);
            Mat affMap1 = GetAffineMap(centerD, angle);
            Mat affMap2 = GetAffineMap(new Point2d(0, 0), 0, 2.0, 1.5);
            Mat affMap3 = GetAffineMap(centerD, angle, 0.7, 0.7);
            Mat affMap4 = GetAffineMap(centerD, angle, 0.7, 0.7, tr);

            // OpenCV의 warpAffine 함수를 사용하여 이미지 변환
            Cv2.WarpAffine(image, dst1, affMap1, image.Size()); // 회전만 적용
            Cv2.WarpAffine(image, dst2, affMap2, image.Size()); // 크기 변경만 적용
            AffineTransform(image, out dst3, affMap3, image.Size()); // 사용자 정의 회전 + 크기 변경
            AffineTransform(image, out dst4, affMap4, image.Size()); // 사용자 정의 회전 + 크기 변경 + 평행 이동

            Cv2.ImShow("image", image);
            Cv2.ImShow("dst1-회전만", dst1);
            Cv2.ImShow("dst2-크기변경만", dst2);
            Cv2.ImShow("dst3-회전+크기변경", dst3);
            Cv2.ImShow("dst4-회전+크기변경+평행이동", dst4);

            Cv2.WaitKey(); 
        }
    }
}
