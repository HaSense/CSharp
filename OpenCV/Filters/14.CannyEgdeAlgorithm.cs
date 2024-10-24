using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannyEgdeAlgorithm
{
    public static class CvUtils
    {
        // 이 함수는 각 픽셀의 x 및 y 방향 그레디언트를 이용해 경사 방향을 계산합니다.
        // 계산된 방향은 4개의 범주 중 하나로 양자화됩니다 (0, 1, 2, 3).
        public static void CalcDirect(Mat Gy, Mat Gx, out Mat direct)
        {
            direct = new Mat(Gy.Size(), MatType.CV_8U);

            for (int i = 0; i < direct.Rows; i++)
            {
                for (int j = 0; j < direct.Cols; j++)
                {
                    float gx = Gx.At<float>(i, j);
                    float gy = Gy.At<float>(i, j);
                    int theta = (int)(Cv2.FastAtan2(gy, gx) / 45);
                    direct.Set(i, j, (byte)(theta % 4));
                }
            }
        }

        // 이 함수는 그레디언트 크기 이미지 (sobel)에서 비최대값 억제를 수행하여 에지를 얇게 만듭니다.
        // 현재 픽셀이 그레디언트 방향에서 지역 최대값인지 확인하고, 최대값이 아닌 경우 억제합니다.
        public static void SuppNonMax(Mat sobel, Mat direct, out Mat dst)
        {
            dst = new Mat(sobel.Size(), MatType.CV_32F, Scalar.All(0));

            for (int i = 1; i < sobel.Rows - 1; i++)
            {
                for (int j = 1; j < sobel.Cols - 1; j++)
                {
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
                    dst.Set(i, j, (center > v1 && center > v2) ? center : 0);
                }
            }
        }

        // 이 함수는 히스테리시스에 의한 에지 추적을 수행합니다.
        // 강한 에지를 따라 재귀적으로 추적하며 약한 에지들을 연결합니다.
        public static void Trace(Mat maxSo, Mat posCk, Mat hyImg, Point pt, float low)
        {
            Rect rect = new Rect(new Point(0, 0), posCk.Size());
            if (!rect.Contains(pt)) return;

            if (posCk.At<byte>(pt.Y, pt.X) == 0 && maxSo.At<float>(pt.Y, pt.X) > low)
            {
                posCk.Set(pt.Y, pt.X, (byte)1);
                hyImg.Set(pt.Y, pt.X, (byte)255);

                Trace(maxSo, posCk, hyImg, pt + new Point(-1, -1), low);
                Trace(maxSo, posCk, hyImg, pt + new Point(0, -1), low);
                Trace(maxSo, posCk, hyImg, pt + new Point(1, -1), low);
                Trace(maxSo, posCk, hyImg, pt + new Point(-1, 0), low);
                Trace(maxSo, posCk, hyImg, pt + new Point(1, 0), low);
                Trace(maxSo, posCk, hyImg, pt + new Point(-1, 1), low);
                Trace(maxSo, posCk, hyImg, pt + new Point(0, 1), low);
                Trace(maxSo, posCk, hyImg, pt + new Point(1, 1), low);
            }
        }

        // 이 함수는 비최대 억제를 거친 그레디언트 크기 이미지 (maxSo)에 대해 히스테리시스 임계값을 적용합니다.
        // 강한 에지를 찾고, 이를 기준으로 낮은 임계값 이상의 연결된 에지를 추적합니다.
        public static void HysteresisTh(Mat maxSo, out Mat hyImg, float low, float high)
        {
            Mat posCk = new Mat(maxSo.Size(), MatType.CV_8U, Scalar.All(0));
            hyImg = new Mat(maxSo.Size(), MatType.CV_8U, Scalar.All(0));

            for (int i = 0; i < maxSo.Rows; i++)
            {
                for (int j = 0; j < maxSo.Cols; j++)
                {
                    if (maxSo.At<float>(i, j) > high)
                    {
                        Trace(maxSo, posCk, hyImg, new Point(j, i), low);
                    }
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:/Temp/opencv/cannay_tset.jpg";
            Mat image = Cv2.ImRead(path, ImreadModes.Grayscale);

            if (image.Empty())
                throw new Exception("Failed to load image");

            Mat gauImg = new Mat();
            Mat Gx = new Mat();
            Mat Gy = new Mat();
            Mat direct = new Mat();
            Mat sobel = new Mat();
            Mat maxSobel = new Mat();
            Mat dst = new Mat();
            Mat canny = new Mat();

            Cv2.GaussianBlur(image, gauImg, new Size(5, 5), 0.3);
            Cv2.Sobel(gauImg, Gx, MatType.CV_32F, 1, 0, 3);
            Cv2.Sobel(gauImg, Gy, MatType.CV_32F, 0, 1, 3);
            Cv2.Magnitude(Gx, Gy, sobel);

            CvUtils.CalcDirect(Gy, Gx, out direct);
            CvUtils.SuppNonMax(sobel, direct, out maxSobel);
            CvUtils.HysteresisTh(maxSobel, out dst, 100, 150);

            Cv2.Canny(image, canny, 100, 150);

            Cv2.ImShow("image", image);
            Cv2.ImShow("canny", dst);
            Cv2.ImShow("OpenCV_canny", canny);
            Cv2.WaitKey();
        }
    }
}
