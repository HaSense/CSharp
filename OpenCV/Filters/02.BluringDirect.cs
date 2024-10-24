using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluringDirect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:/Temp/opencv/filter_blur.jpg";
            Mat src = Cv2.ImRead(path, ImreadModes.Grayscale);

            if (src.Empty())
                throw new Exception("이미지 문제발생");

            Mat blur = new Mat();

            // OpenCV 함수인 GaussianBlur를 사용하여 블러링 처리
            Cv2.GaussianBlur(src, blur, new Size(3, 3), 0); //Size 함수의 3을 5로 바꾸면 5 * 5 필터가 되고 1/25f가 입력됨

            Cv2.ImShow("src", src);
            Cv2.ImShow("blur", blur);

            Cv2.WaitKey();
        }
    }
}
