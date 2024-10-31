using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FindCoins_V1_oop
{
    // 동전 검출기 클래스
    public class CoinDetector
    {
        // 이미지 전처리 메서드
        public Mat PreprocessImage(Mat img)
        {
            Mat gray = new Mat();
            Mat dst = new Mat();
            Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY); // 이미지를 회색조로 변환
            Cv2.GaussianBlur(gray, gray, new Size(7, 7), 2, 2); // 가우시안 블러 적용하여 노이즈 감소

            // 오츠 알고리즘을 사용하여 이진화 수행
            Cv2.Threshold(gray, dst, 130, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);
            // 형태학적 변환 (Opening)을 적용하여 작은 잡음 제거
            Cv2.MorphologyEx(dst, dst, MorphTypes.Open, new Mat(), null, 1);
            return dst;
        }

        // 외곽선에서 회전된 사각형을 검출하는 메서드
        public List<RotatedRect> FindCoins(Mat img)
        {
            Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(img.Clone(), out contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            List<RotatedRect> circles = new List<RotatedRect>();
            foreach (var contour in contours)
            {
                RotatedRect rotatedRect = Cv2.MinAreaRect(contour);
                float radius = (rotatedRect.Size.Width + rotatedRect.Size.Height) / 4.0f;

                if (radius > 18)
                    circles.Add(rotatedRect);
            }
            return circles;
        }

        // 회전된 사각형을 그리는 유틸리티 메서드
        public void DrawRotatedRect(Mat img, RotatedRect rotatedRect, Scalar color, int thickness = 2)
        {
            Point2f[] points = rotatedRect.Points();
            for (int i = 0; i < 4; ++i)
            {
                Cv2.Line(img, new Point(points[i].X, points[i].Y), new Point(points[(i + 1) % 4].X, points[(i + 1) % 4].Y), color, thickness);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int coinNo = 70; // 테스트할 동전 이미지 번호
            string fname = string.Format(@"c:/Temp/opencv/{0:D2}.png", coinNo);
            Mat image = Cv2.ImRead(fname, ImreadModes.Color); 
            if (image.Empty())
            {
                Console.WriteLine("이미지를 불러올 수 없습니다.");
                return;
            }

            // CoinDetector 객체 생성
            CoinDetector detector = new CoinDetector();

            // 전처리 실행
            Mat thImg = detector.PreprocessImage(image); // 전처리된 이진화 이미지 생성
            List<RotatedRect> circles = detector.FindCoins(thImg); // 동전 검출

            // 검출된 동전을 원으로 표시
            foreach (var circle in circles)
            {
                float radius = (circle.Size.Width + circle.Size.Height) / 4.0f; // 반지름 계산
                Cv2.Circle(image, new Point((int)circle.Center.X, (int)circle.Center.Y), (int)radius, new Scalar(0, 255, 0), 2); // 동전 표시
            }

            Cv2.ImShow("전처리영상", thImg);
            Cv2.ImShow("동전영상", image);
            Cv2.WaitKey();
        }
    }
}
