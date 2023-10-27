using OpenCvSharp;
using System;
using System.Collections.Generic;

namespace CannyEdge
{
    internal class Program
    {
        // 방향성을 계산하는 함수
        static void CalcDirect(Mat Gy, Mat Gx, out Mat direct)
        {
            direct = new Mat(Gy.Size(), MatType.CV_8U, Scalar.All(0));

            for (int i = 0; i < direct.Rows; i++)
            {
                for (int j = 0; j < direct.Cols; j++)
                {
                    // 해당 픽셀의 x, y 방향의 기울기를 가져옴
                    float gx = Gx.At<float>(i, j);
                    float gy = Gy.At<float>(i, j);
                    // atan2를 사용해 각도를 구하고 45로 나눔
                    int theta = (int)(Cv2.FastAtan2(gy, gx) / 45);
                    direct.Set<byte>(i, j, (byte)(theta % 4));
                }
            }
        }

        // 최대 억제(non-maximum suppression)를 수행하는 함수
        static void SuppNonMax(Mat sobel, Mat direct, out Mat dst)
        {
            dst = new Mat(sobel.Size(), MatType.CV_32F, Scalar.All(0));

            for (int i = 1; i < sobel.Rows - 1; i++)
            {
                for (int j = 1; j < sobel.Cols - 1; j++)
                {
                    // 방향성 값을 기반으로 인접 픽셀의 값을 가져옴
                    int dir = direct.At<byte>(i, j);
                    float v1, v2;

                    if (dir == 0)
                    {
                        v1 = sobel.At<float>(i, j - 1);
                        v2 = sobel.At<float>(i, j + 1);
                    }
                    else if (dir == 1)
                    {
                        v1 = sobel.At<float>(i + 1, j + 1);
                        v2 = sobel.At<float>(i - 1, j - 1);
                    }
                    else if (dir == 2)
                    {
                        v1 = sobel.At<float>(i - 1, j);
                        v2 = sobel.At<float>(i + 1, j);
                    }
                    else
                    {
                        v1 = sobel.At<float>(i + 1, j - 1);
                        v2 = sobel.At<float>(i - 1, j + 1);
                    }

                    float center = sobel.At<float>(i, j);
                    // 중심 픽셀이 인접 픽셀보다 큰 경우에만 값을 보존
                    dst.Set<float>(i, j, (center > v1 && center > v2) ? center : 0);
                }
            }
        }

        // 임계값을 기반으로 엣지 트레이싱을 수행하는 함수
        static void Trace(Mat maxSo, Mat posCk, Mat hyImg, Point pt, int low)
        {
            Rect rect = new Rect(new Point(0, 0), posCk.Size());
            if (!rect.Contains(pt)) return;

            if (posCk.At<byte>(pt.Y, pt.X) == 0 && maxSo.At<float>(pt.Y, pt.X) > low)
            {
                posCk.Set<byte>(pt.Y, pt.X, 1);
                hyImg.Set<byte>(pt.Y, pt.X, 255);

                List<Point> points = new List<Point>
        {
            new Point(-1, -1), new Point(0, -1), new Point(1, -1),
            new Point(-1, 0), new Point(1, 0),
            new Point(-1, 1), new Point(0, 1), new Point(1, 1)
        };

                foreach (var point in points)
                {
                    Trace(maxSo, posCk, hyImg, pt + point, low);
                }
            }
        }

        // 이중 임계값 처리를 수행하는 함수
        static void HysteresisTh(Mat maxSo, out Mat hyImg, int low, int high)
        {
            Mat posCk = new Mat(maxSo.Size(), MatType.CV_8U, Scalar.All(0));
            hyImg = new Mat(maxSo.Size(), MatType.CV_8U, Scalar.All(0));

            for (int i = 0; i < maxSo.Rows; i++)
            {
                for (int j = 0; j < maxSo.Cols; j++)
                {
                    if (maxSo.At<float>(i, j) > high)
                        Trace(maxSo, posCk, hyImg, new Point(j, i), low);
                }
            }
        }

        static void Main(string[] args)
        {
            // 이미지를 불러옴
            Mat image = Cv2.ImRead("c:\\Temp\\img\\cannay_test.jpg", ImreadModes.Grayscale);
            if (image.Empty()) throw new Exception("이미지 로딩 실패!");

            Mat gauImg = new Mat();
            Mat Gx = new Mat();
            Mat Gy = new Mat();
            Mat direct = new Mat();
            Mat sobel = new Mat();
            Mat maxSobel = new Mat();
            Mat hyImg = new Mat();
            Mat canny = new Mat();

            // 가우시안 블러 처리
            Cv2.GaussianBlur(image, gauImg, new Size(5, 5), 0.3);
            // Sobel 필터로 엣지 감지
            Cv2.Sobel(gauImg, Gx, MatType.CV_32F, 1, 0, 3);
            Cv2.Sobel(gauImg, Gy, MatType.CV_32F, 0, 1, 3);
            sobel = Gx.Abs() + Gy.Abs();

            CalcDirect(Gy, Gx, out direct);
            SuppNonMax(sobel, direct, out maxSobel);
            HysteresisTh(maxSobel, out hyImg, 100, 150);

            // OpenCV의 Canny 함수로 엣지 감지
            Cv2.Canny(image, canny, 100, 150);

            // 결과 표시
            Cv2.ImShow("이미지", image);
            Cv2.ImShow("캐니", hyImg);
            Cv2.ImShow("OpenCV 캐니", canny);
            Cv2.WaitKey();
        }
    }
}
