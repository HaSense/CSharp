using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OpenCloseApp
{
    internal class Program
    {
        // 마스크 원소와 마스크 범위 입력화소 간의 일치 여부 체크
        static bool CheckMatch(Mat img, Point start, Mat mask, int mode = 0)
        {
            for (int u = 0; u < mask.Rows; u++)
            {
                for (int v = 0; v < mask.Cols; v++)
                {
                    Point pt = new Point(v, u);
                    int m = mask.At<byte>(pt.Y, pt.X);  // 마스크 계수
                    int p = img.At<byte>(start.Y + pt.Y, start.X + pt.X);  // 해당 위치 입력화소

                    bool ch = (p == 255);  // 일치 여부 비교
                    if (m == 1 && ch == (mode == 1)) return false;
                }
            }
            return true;
        }

        // 침식 연산 함수
        static void Erosion(Mat img, Mat dst, Mat mask)
        {
            dst.SetTo(0);

            if (mask.Empty())
                mask = Mat.Ones(3, 3, MatType.CV_8UC1);

            Point maskCenter = new Point(mask.Cols / 2, mask.Rows / 2);
            for (int i = maskCenter.Y; i < img.Rows - maskCenter.Y; i++)
            {
                for (int j = maskCenter.X; j < img.Cols - maskCenter.X; j++)
                {
                    Point start = new Point(j, i) - maskCenter;
                    bool check = CheckMatch(img, start, mask, 0);
                    dst.Set<byte>(i, j, check ? (byte)255 : (byte)0);
                }
            }
        }

        // 팽창 연산 함수
        static void Dilation(Mat img, Mat dst, Mat mask)
        {
            dst.SetTo(0);

            if (mask.Empty())
                mask = Mat.Ones(3, 3, MatType.CV_8UC1);

            Point maskCenter = new Point(mask.Cols / 2, mask.Rows / 2);
            for (int i = maskCenter.Y; i < img.Rows - maskCenter.Y; i++)
            {
                for (int j = maskCenter.X; j < img.Cols - maskCenter.X; j++)
                {
                    Point start = new Point(j, i) - maskCenter;
                    bool check = CheckMatch(img, start, mask, 1);
                    dst.Set<byte>(i, j, check ? (byte)0 : (byte)255);
                }
            }
        }

        // 열림 연산 함수
        static void Opening(Mat img, Mat dst, Mat mask)
        {
            Mat tmp = new Mat(dst.Size(), dst.Type());
            Erosion(img, tmp, mask);
            Dilation(tmp, dst, mask);
        }

        // 닫힘 연산 함수
        static void Closing(Mat img, Mat dst, Mat mask)
        {
            Mat tmp = new Mat(dst.Size(), dst.Type());
            Dilation(img, tmp, mask);
            Erosion(tmp, dst, mask);
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead("c:\\Temp\\img\\morph_test1.jpg", ImreadModes.Grayscale);
            if (image.Empty())
                throw new Exception("이미지를 불러올 수 없습니다.");

            Mat thImg = new Mat();
            Cv2.Threshold(image, thImg, 128, 255, ThresholdTypes.Binary);

            var mask = new Mat(3, 3, MatType.CV_8UC1, new byte[] { 0, 1, 0, 1, 1, 1, 0, 1, 0 });

            Mat dst1 = new Mat(image.Size(), image.Type());
            Opening(thImg, dst1, mask);
            Mat dst2 = new Mat(image.Size(), image.Type());
            Closing(thImg, dst2, mask);
            Mat dst3 = thImg.Clone();
            Cv2.MorphologyEx(thImg, dst3, MorphTypes.Open, mask);
            Mat dst4 = thImg.Clone();
            Cv2.MorphologyEx(thImg, dst4, MorphTypes.Close, mask);

            Cv2.ImShow("User_opening", dst1);
            Cv2.ImShow("User_closing", dst2);
            Cv2.ImShow("OpenCV_opening", dst3);
            Cv2.ImShow("OpenCV_closing", dst4);

            Cv2.WaitKey();
        }
    }
}
