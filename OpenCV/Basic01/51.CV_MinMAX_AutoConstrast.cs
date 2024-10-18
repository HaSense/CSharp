using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVAutoConstrast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 이미지 파일 경로
            string imagePath = @"c:/Temp/opencv/minMax.jpg";

            // 이미지를 그레이스케일로 읽기
            Mat image = Cv2.ImRead(imagePath, ImreadModes.Grayscale);

            // 예외 처리
            if (image.Empty())
            {
                throw new Exception("이미지를 불러올 수 없습니다.");
            }

            // 최소값, 최대값 찾기
            double minVal, maxVal;
            Cv2.MinMaxIdx(image, out minVal, out maxVal);

            // 최소값과 최대값을 사용하여 이미지 정규화
            double ratio = (maxVal - minVal) / 255.0;
            Mat dst = new Mat();
            image.ConvertTo(dst, MatType.CV_64F);  // 계산을 위해 이미지 타입을 CV_64F로 변환
            Cv2.Subtract(dst, new Scalar(minVal), dst);  // dst에서 minVal을 빼기

            // 나누기 연산 수행
            Cv2.Divide(dst, new Scalar(ratio), dst);  // ratio로 나누기

            // 계산된 결과를 다시 CV_8U로 변환하여 시각화
            dst.ConvertTo(dst, MatType.CV_8U);

            // 결과 출력
            Console.WriteLine("최소값  = " + minVal);
            Console.WriteLine("최대값  = " + maxVal);

            // 이미지 출력
            Cv2.ImShow("image", image);
            Cv2.ImShow("dst", dst);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
