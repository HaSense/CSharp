using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannyDirect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:/Temp/opencv/canny_test.jpg";
            Mat image = Cv2.ImRead(path, ImreadModes.Grayscale);

            if (image.Empty())
                throw new Exception("이미지 로드 실패");

            Mat canny = new Mat();

            // OpenCV의 Canny 함수를 사용하여 에지 검출 수행
            // Canny 함수의 세 번째와 네 번째 매개변수는 각각 낮은 임계값(100)과 높은 임계값(150)을 의미합니다.
            // 이 두 임계값을 통해 에지를 구분하며, 높은 임계값(150)보다 큰 경사 값은 확실한 에지로 간주되고,
            // 낮은 임계값(100)과 높은 임계값 사이에 있는 값은 연결된 경우에만 에지로 간주됩니다.
            Cv2.Canny(image, canny, 100, 150);

            // 원본 이미지 및 Canny 에지 결과 출력
            Cv2.ImShow("image", image);
            Cv2.ImShow("OpenCV_canny", canny);
            Cv2.WaitKey();
        }
    }
}
