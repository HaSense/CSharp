using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalingNearset
{
    internal class Program
    {
        // 크기 변경 함수 - 순방향 사상
        static void Scaling(Mat img, Mat dst, Size size)
        {
            dst.Create(size, img.Type());
            dst.SetTo(0);

            double ratioY = (double)size.Height / img.Rows;  // 세로 변경 비율 
            double ratioX = (double)size.Width / img.Cols;    // 가로 변경 비율 

            for (int i = 0; i < img.Rows; i++)
            {
                for (int j = 0; j < img.Cols; j++)
                {
                    int x = (int)(j * ratioX);
                    int y = (int)(i * ratioY);
                    dst.At<byte>(y, x) = img.At<byte>(i, j);
                }
            }
        }

        // 최근접 이웃 보간 함수 - 역방향 사상
        static void ScalingNearest(Mat img, Mat dst, Size size)
        {
            dst.Create(size, MatType.CV_8U);
            dst.SetTo(0);

            double ratioY = (double)size.Height / img.Rows;
            double ratioX = (double)size.Width / img.Cols;

            for (int i = 0; i < dst.Rows; i++)
            {
                for (int j = 0; j < dst.Cols; j++)
                {
                    int x = (int)Math.Round(j / ratioX);
                    int y = (int)Math.Round(i / ratioY);
                    dst.At<byte>(i, j) = img.At<byte>(y, x);
                }
            }
        }
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead("C:\\Temp\\img\\interpolation_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
                throw new Exception("이미지를 불러올 수 없습니다.");

            Mat dst1 = new Mat();
            Mat dst2 = new Mat();

            Scaling(image, dst1, new Size(300, 300));          // 크기변경 - 기본
            ScalingNearest(image, dst2, new Size(300, 300));   // 크기변경 – 최근접 이웃

            Cv2.ImShow("image", image);
            Cv2.ImShow("dst1-순방향사상", dst1);
            Cv2.ImShow("dst2-최근접 이웃보간", dst2);

            Cv2.WaitKey();
        }
    }
}
