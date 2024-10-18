using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatAbs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 이미지 파일 경로
            string imagePath1 = @"c:/Temp/opencv/abs_test1.jpg";
            string imagePath2 = @"c:/Temp/opencv/abs_test2.jpg";

            // 이미지를 그레이스케일로 읽기
            Mat image1 = Cv2.ImRead(imagePath1, ImreadModes.Grayscale);
            Mat image2 = Cv2.ImRead(imagePath2, ImreadModes.Grayscale);

            // 예외 처리
            if (image1.Empty() || image2.Empty())
            {
                throw new Exception("이미지를 불러올 수 없습니다.");
            }

            // 결과 행렬 선언
            Mat difImg = new Mat();
            Mat absDif1 = new Mat();
            Mat absDif2 = new Mat();

            // 이미지 타입을 CV_16S로 변환
            image1.ConvertTo(image1, MatType.CV_16S);
            image2.ConvertTo(image2, MatType.CV_16S);

            // 두 이미지의 차이를 계산
            Cv2.Subtract(image1, image2, difImg);

            // 관심 영역 출력
            Rect roi = new Rect(10, 10, 7, 3);
            Console.WriteLine("[difImg] = \n" + difImg[roi]);

            // 차이 이미지의 절대값 계산
            absDif1 = Cv2.Abs(difImg);

            // 이미지 타입을 다시 CV_8U로 변환
            image1.ConvertTo(image1, MatType.CV_8U);
            image2.ConvertTo(image2, MatType.CV_8U);
            difImg.ConvertTo(difImg, MatType.CV_8U);
            absDif1.ConvertTo(absDif1, MatType.CV_8U);

            // 두 이미지의 절대 차이 계산
            Cv2.Absdiff(image1, image2, absDif2);

            // 관심 영역 출력
            Console.WriteLine("[difImg] = \n" + difImg[roi] + "\n");
            Console.WriteLine("[absDif1] = \n" + absDif1[roi]);
            Console.WriteLine("[absDif2] = \n" + absDif2[roi]);

            // 결과 이미지 출력
            Cv2.ImShow("image1", image1);
            Cv2.ImShow("image2", image2);
            Cv2.ImShow("difImg", difImg);
            Cv2.ImShow("absDif1", absDif1);
            Cv2.ImShow("absDif2", absDif2);

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
