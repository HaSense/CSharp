using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpologyDilation
{
    
    internal class Program
    {
        static bool CheckMatch(Mat img, Point start, Mat mask, int mode)
        {
            for (int u = 0; u < mask.Rows; u++)
            {
                for (int v = 0; v < mask.Cols; v++)
                {
                    int m = mask.At<byte>(u, v); // 마스크 계수
                    int p = img.At<byte>(start.Y + u, start.X + v); // 해당 위치 입력화소

                    bool ch = (p == 255); // 일치 여부 비교
                    if (m == 1 && ch == (mode == 1)) return false;
                }
            }
            return true;
        }

        // 팽창 연산을 수행하는 함수
        static void Dilation(Mat img, Mat dst, Mat mask)
        {
            // 결과 이미지 초기화
            dst.SetTo(0);

            // 마스크가 제공되지 않았다면 기본 3x3 마스크 생성
            if (mask.Empty())
                mask = Mat.Ones(3, 3, MatType.CV_8UC1);

            // 마스크의 중심 좌표 계산
            Point maskCenter = new Point(mask.Cols / 2, mask.Rows / 2);

            // 이미지 순회
            for (int i = maskCenter.Y; i < img.Rows - maskCenter.Y; i++)
            {
                for (int j = maskCenter.X; j < img.Cols - maskCenter.X; j++)
                {
                    // 현재 픽셀을 중심으로 마스크를 적용할 시작 좌표 계산
                    Point start = new Point(j, i) - maskCenter;

                    // 이미지의 해당 부분과 마스크가 일치하는지 확인
                    bool check = CheckMatch(img, start, mask, 1);

                    // 팽창 연산 수행
                    dst.Set<byte>(i, j, check ? (byte)0 : (byte)255);
                }
            }
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"c:/Temp/opencv/morph_test1.jpg", ImreadModes.Grayscale);
            if (image.Empty())
                throw new Exception("이미지를 불러올 수 없습니다.");

            Mat thImg = new Mat();
            Cv2.Threshold(image, thImg, 128, 255, ThresholdTypes.Binary);

            var mask = new Mat(3, 3, MatType.CV_8UC1);
            byte[,] values = {
                { 0, 1, 0 },
                { 1, 1, 1 },
                { 0, 1, 1 }
            };
            for (int i = 0; i < mask.Rows; i++)
            {
                for (int j = 0; j < mask.Cols; j++)
                {
                    mask.Set(i, j, values[i, j]);
                }
            }

            Mat dst1 = image.Clone();
            Dilation(thImg, dst1, mask);

            Mat dst2 = new Mat();
            Cv2.MorphologyEx(thImg, dst2, MorphTypes.Dilate, mask);

            Cv2.ImShow("image", image);
            Cv2.ImShow("팽창 사용자정의 함수", dst1);
            Cv2.ImShow("OpenCV 팽창 함수", dst2);

            Cv2.WaitKey();
        }
    }
}
