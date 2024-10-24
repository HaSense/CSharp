using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxFilterApp
{
    internal class Program
    {
        static void MinMaxFilter(Mat img, out Mat dst, int size, int flag = 1)
        {
            dst = new Mat(img.Size(), MatType.CV_8U, Scalar.All(0));
            Size msize = new Size(size, size);
            
            Point h_m = new Point(msize.Width / 2, msize.Height / 2);   //h_m half of mask의 약자 mask의 중심점

            for (int i = h_m.Y; i < img.Rows - h_m.Y; i++)
            {
                for (int j = h_m.X; j < img.Cols - h_m.X; j++)
                {
                    Point start = new Point(j, i) - h_m;
                    Rect roi = new Rect(start, msize); // 마스크 영역 사각형
                    Mat mask = new Mat(img, roi); // 마스크 영역 참조

                    double minVal, maxVal;
                    Cv2.MinMaxLoc(mask, out minVal, out maxVal); // 마스크 영역 최소, 최대값
                    dst.Set(i, j, (byte)((flag != 0) ? maxVal : minVal));
                }
            }
        }
        static void Main(string[] args)
        {
            string path = @"C:/Temp/opencv/median_test1.jpg"; //시계그림 이름이 바뀌어 있네요 체크~!
            Mat image = Cv2.ImRead(path, ImreadModes.Grayscale);

            if (image.Empty())
                throw new Exception("이미지를 불러올 수 없습니다.");

            Mat minImg, maxImg;
            MinMaxFilter(image, out minImg, 5, 0); // 5x5 마스크 최소값 필터링
            MinMaxFilter(image, out maxImg, 5, 1); // 5x5 마스크 최대값 필터링

            Mat cvMinImg = new Mat();
            Mat cvMaxImg = new Mat();

            // OpenCV의 Erode()와 Dilate() 함수를 사용한 최소값 및 최대값 필터링
            Cv2.Erode(image, cvMinImg, new Mat(), iterations: 1); // 최소값 필터링
            Cv2.Dilate(image, cvMaxImg, new Mat(), iterations: 1); // 최대값 필터링

            // 결과 출력
            Cv2.ImShow("image", image);
            Cv2.ImShow("minFilter_img", minImg);
            Cv2.ImShow("maxFilter_img", maxImg);
            Cv2.ImShow("cvMinFilter_img", cvMinImg);
            Cv2.ImShow("cvMaxFilter_img", cvMaxImg);
            Cv2.WaitKey();
        }
    }
}
