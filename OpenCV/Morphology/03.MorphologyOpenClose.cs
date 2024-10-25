using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorphologyOpenClose
{
    class CvUtils
    {
        // 두 이미지와 마스크가 일치하는지 여부를 확인하는 함수
        public bool CheckMatch(Mat img, Point start, Mat mask, int mode = 0)
        {
            for(int u = 0; u < mask.Rows; u++)
            {
                for (int v = 0; v < mask.Cols; v++)
                {
                    Point pt = new Point(v, u);
                    byte m = mask.Get<byte>(u, v); // 마스크 계수
                    byte p = img.Get<byte>(start.Y + u, start.X + v); // 해당 위치 입력화소

                    bool ch = (p == 0); // 일치 여부 비교 (검은 바탕에 하얀 글씨)
                    if (m == 1 && ch == (mode == 0))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // 침식 연산 함수
        public void Erosion(Mat img, Mat dst, Mat mask)
        {
            dst.Create(img.Size(), MatType.CV_8UC1);
            dst.SetTo(Scalar.Black);
            Point h_m = new Point(mask.Cols / 2, mask.Rows / 2);

            for (int i = h_m.Y; i < img.Rows - h_m.Y; i++)
            {
                for (int j = h_m.X; j < img.Cols - h_m.X; j++)
                {
                    Point start = new Point(j, i) - h_m;
                    
                    bool check = CheckMatch(img, start, mask, 0);
                    dst.Set<byte>(i, j, (byte)(check ? 255 : 0));
                }
                
            }
        }

        // 팽창 연산 함수
        public void Dilation(Mat img, Mat dst, Mat mask)
        {
            dst.Create(img.Size(), MatType.CV_8UC1);
            dst.SetTo(Scalar.White);
            Point h_m = new Point(mask.Cols / 2, mask.Rows / 2);

            for (int i = h_m.Y; i < img.Rows - h_m.Y; i++)
            {
                for (int j = h_m.X; j < img.Cols - h_m.X; j++)
                {
                    Point start = new Point(j, i) - h_m;
                    bool check = CheckMatch(img, start, mask, 1);
                    dst.Set<byte>(i, j, (byte)(check ? 0 : 255));
                }
            }
        }

        // 열기 연산 함수
        public void Opening(Mat img, Mat dst, Mat mask)
        {
            Mat tmp = new Mat();
            Erosion(img, tmp, mask);
            Dilation(tmp, dst, mask);
        }

        // 닫기 연산 함수
        public void Closing(Mat img, Mat dst, Mat mask)
        {
            Mat tmp = new Mat();
            Dilation(img, tmp, mask);
            Erosion(tmp, dst, mask);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 이미지 읽기 - 그림의 경로는 "C:/Temp/opencv/"로 지정
            Mat image = Cv2.ImRead(@"C:/Temp/opencv/morph_test1.jpg", ImreadModes.Grayscale);
            if (image.Empty())
            {
                Console.WriteLine("이미지를 불러올 수 없습니다. 경로를 확인해주세요.");
                return;
            }

            // 이진화 작업
            Mat th_img = new Mat();
            Cv2.Threshold(image, th_img, 128, 255, ThresholdTypes.Binary);

            // 마스크 행렬 정의 (3x3 형태)
            Mat mask = new Mat(3, 3, MatType.CV_8UC1);
            byte[,] values = {
                { 0, 1, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 }
            };
            for (int i = 0; i < mask.Rows; i++)
            {
                for (int j = 0; j < mask.Cols; j++)
                {
                    mask.Set(i, j, values[i, j]);
                }
            }

            // 열기 연산 수행 (사용자 정의)
            Mat dst1 = new Mat();
            CvUtils cvUtils = new CvUtils();
            cvUtils.Opening(th_img, dst1, mask);

            // 닫기 연산 수행 (사용자 정의)
            Mat dst2 = new Mat();
            cvUtils.Closing(th_img, dst2, mask);

            // OpenCV 제공 열기 연산 함수 사용
            Mat dst3 = new Mat();
            Cv2.MorphologyEx(th_img, dst3, MorphTypes.Open, mask);

            // OpenCV 제공 닫기 연산 함수 사용
            Mat dst4 = new Mat();
            Cv2.MorphologyEx(th_img, dst4, MorphTypes.Close, mask);

            // 결과 이미지 출력
            Cv2.ImShow("User_opening", dst1);
            Cv2.ImShow("User_closing", dst2);
            Cv2.ImShow("OpenCV_opening", dst3);
            Cv2.ImShow("OpenCV_closing", dst4);
            Cv2.WaitKey();
        }
    }
}
