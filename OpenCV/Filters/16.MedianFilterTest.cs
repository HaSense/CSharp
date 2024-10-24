using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianFilterTest
{
    internal class Program
    {
        static void MedianFilter(Mat img, out Mat dst, int size)
        {
            dst = new Mat(img.Size(), MatType.CV_8U, Scalar.All(0));
            Size msize = new Size(size, size);
            Point h_m = new Point(msize.Width / 2, msize.Height / 2);

            for (int i = h_m.Y; i < img.Rows - h_m.Y; i++)
            {
                for (int j = h_m.X; j < img.Cols - h_m.X; j++)
                {
                    Point start = new Point(j, i) - h_m;
                    Rect roi = new Rect(start, msize);
                    Mat mask = new Mat(img, roi);

                    // 플랫하게 벡터로 변환하는 방식으로 수정 (직접 순환하면서 값을 넣음)
                    byte[] maskArray = new byte[mask.Rows * mask.Cols];
                    int index = 0;
                    for (int y = 0; y < mask.Rows; y++)
                    {
                        for (int x = 0; x < mask.Cols; x++)
                        {
                            maskArray[index++] = mask.At<byte>(y, x);
                        }
                    }
                    Array.Sort(maskArray);

                    int mediIdx = maskArray.Length / 2; // 중간 위치
                    dst.Set(i, j, maskArray[mediIdx]); // 중간값
                }
            }
        }
        static void Main(string[] args)
        {
            string path = @"C:/Temp/opencv/median_test.jpg";
            Mat image = Cv2.ImRead(path, ImreadModes.Color);

            if (image.Empty())
                throw new Exception("이미지를 불러올 수 없습니다.");

            Mat gray = new Mat();
            Mat medImg1 = new Mat();
            Mat medImg2 = new Mat();
            Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);

            MedianFilter(gray, out medImg1, 5); // 사용자 정의 함수
            Cv2.MedianBlur(gray, medImg2, 5); // OpenCV 제공 함수

            Cv2.ImShow("gray", gray);
            Cv2.ImShow("median-User", medImg1);
            Cv2.ImShow("median-OpenCV", medImg2);

            Cv2.WaitKey();
        }
    }
}
