using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectPlate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("차량 영상 번호( 0:종료 ) : ");
                if (!int.TryParse(Console.ReadLine(), out int no) || no == 0)
                    break;

                string fname = $"C:/Temp/opencv/test_car/{no:D2}.jpg"; //두 자리로 꼭 사용하세요. 숫자 01, 11, 12 등
                Mat image = new Mat(fname, ImreadModes.Color);

                if (image.Empty())
                {
                    Console.WriteLine($"{no}번 영상 파일이 없습니다.");
                    continue;
                }

                Mat gray = new Mat();
                Mat sobel = new Mat();
                Mat thImg = new Mat();
                Mat morph = new Mat();

                // 닫힘 연산 마스크 생성
                Mat kernel = Mat.Ones(new Size(31, 5), MatType.CV_8UC1);

                // 명암도 영상 변환
                Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);

                // 블러링을 통한 전처리
                Cv2.Blur(gray, gray, new Size(5, 5));

                // 소벨 알고리즘으로 경계(에지 검출한다)
                Cv2.Sobel(gray, sobel, MatType.CV_8U, 1, 0, 3);

                // 이진화를 수행한다.
                Cv2.Threshold(sobel, thImg, 120, 255, ThresholdTypes.Binary);

                // 닫음 연산 - 팽창 후 침식을 통해 경계를 명확히 분리한다
                Cv2.MorphologyEx(thImg, morph, MorphTypes.Close, kernel);

                // 결과 표시
                Cv2.ImShow("image", image);
                Cv2.ImShow("이진 영상", thImg);
                Cv2.ImShow("닫음 연산", morph);
                Cv2.WaitKey(2000);
            }
        }
    }
}
