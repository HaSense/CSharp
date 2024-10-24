using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageFilterTest
{
    internal class Program
    {
        static void AverageFilter(Mat img, out Mat dst, int size)
        {
            dst = new Mat(img.Size(), MatType.CV_8U, Scalar.All(0));

            for (int i = 0; i < img.Rows; i++)
            {
                for (int j = 0; j < img.Cols; j++)
                {
                    Point pt1 = new Point(j - size / 2, i - size / 2);
                    Point pt2 = pt1 + new Point(size, size);

                    if (pt1.X < 0) pt1.X = 0;
                    if (pt1.Y < 0) pt1.Y = 0;
                    if (pt2.X > img.Cols) pt2.X = img.Cols;
                    if (pt2.Y > img.Rows) pt2.Y = img.Rows;

                    Rect maskRect = new Rect(pt1.X, pt1.Y, pt2.X - pt1.X, pt2.Y - pt1.Y);
                    Mat mask = new Mat(img, maskRect);
                    dst.Set(i, j, (byte)Cv2.Mean(mask)[0]);
                }
            }
        }
        static void Main(string[] args)
        {
            string path = @"C:/Temp/opencv/avg_filter.jpg";
            Mat image = Cv2.ImRead(path, ImreadModes.Grayscale);

            if (image.Empty())
                throw new Exception("이미지를 불러올 수 없습니다.");

            Mat avgImg = new Mat();
            Mat blurImg = new Mat();
            Mat boxImg = new Mat();

            AverageFilter(image, out avgImg, 5); // 사용자 정의 함수
            Cv2.Blur(image, blurImg, new Size(5, 5)); // OpenCV 제공 블러 필터
            Cv2.BoxFilter(image, boxImg, -1, new Size(5, 5)); // OpenCV 제공 박스 필터

            Cv2.ImShow("원본", image);
            Cv2.ImShow("avg_Filter 구현 알고리즘", avgImg);
            Cv2.ImShow("OpenCV blur", blurImg);
            Cv2.ImShow("OpenCV BoxFilter", boxImg);

            Cv2.WaitKey();
        }
    }
}
