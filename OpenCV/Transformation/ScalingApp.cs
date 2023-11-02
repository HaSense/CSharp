using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//비율에 맞춰 그림을 크게 또는 작게 변경할 때의 변화를 확인하세요.
//비율에 맞게 크게 했을 때 화소들 사이에 비는 공간을 확인하세요.

namespace ScalingApp
{
    internal class Program
    {
        // 크기 변경 함수
        static void Scaling(Mat img, Mat dst, Size size)
        {
            dst.Create(size, img.Type()); // 목적영상 생성
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
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead("C:\\Temp\\img\\scaling_test.jpg", ImreadModes.Grayscale);
            if (image.Empty())
                throw new Exception("이미지를 불러올 수 없습니다.");

            Mat dst1 = new Mat();
            Mat dst2 = new Mat();

            Scaling(image, dst1, new Size(150, 200));  // 크기변경 수행 - 축소
            Scaling(image, dst2, new Size(300, 400));  // 크기변경 수행 - 확대

            Cv2.ImShow("image", image);
            Cv2.ImShow("dst1-축소", dst1);
            Cv2.ImShow("dst2-확대", dst2);
            Cv2.ResizeWindow("dst1-축소", 300, 400);    // 윈도우 크기 확장

            Cv2.WaitKey();
        }
    }
}
