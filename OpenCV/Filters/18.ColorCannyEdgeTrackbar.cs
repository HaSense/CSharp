using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ColorCannyEdgeTrackbar
{
    
    internal class Program
    {
        private static Mat image, gray, edge;
        private static int th = 50; // 캐니 에지 낮은 임계값

        private static void OnTrackbar(int pos, IntPtr userdata)
        {
            th = pos;
            // 가우시안 블러링 및 캐니 에지 수행
            edge = new Mat();
            
            Cv2.GaussianBlur(gray, edge, new OpenCvSharp.Size(3, 3), 0.7);
            Cv2.Canny(edge, edge, th, th * 2, 3);

            Mat colorEdge = new Mat();
            image.CopyTo(colorEdge, edge); // 에지 영역만 복사

            // 결과 이미지 표시
            Cv2.ImShow("컬러 에지", colorEdge);
        }
        static void Main(string[] args)
        {
            string path = @"C:/Temp/opencv/smoothing.jpg";
            image = Cv2.ImRead(path, ImreadModes.Color);

            if (image.Empty())
            {
                Console.WriteLine("이미지를 불러올 수 없습니다.");
                return;
            }

            gray = new Mat();
            Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);

            // OpenCV 창 설정 및 트랙바 생성
            Cv2.NamedWindow("컬러 에지", WindowFlags.AutoSize);
            Cv2.CreateTrackbar("Canny th", "컬러 에지", ref th, 100, OnTrackbar);
            OnTrackbar(0, IntPtr.Zero); // 초기 트랙바 함수 호출

            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
    
}
