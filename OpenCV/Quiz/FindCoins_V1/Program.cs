using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FindCoins_V1
{
    internal class Program
    {
        // 회전된 사각형을 그리는 함수
        static void DrawRotatedRect(Mat img, RotatedRect rotatedRect, Scalar color, int thickness = 2)
        {
            Point2f[] points = rotatedRect.Points(); // RotatedRect의 각 꼭짓점 좌표를 가져옴
            for (int i = 0; i < 4; ++i)
            {
                // 사각형의 각 변을 그리기 위해 순환 연결
                Cv2.Line(img, new Point(points[i].X, points[i].Y), new Point(points[(i + 1) % 4].X, points[(i + 1) % 4].Y), color, thickness);
            }
        }

        // 이미지 전처리 함수
        static Mat Preprocessing(Mat img) // 전처리 함수
        {
            Mat gray = new Mat(); // 회색조 이미지 저장용
            Mat dst = new Mat(); // 이진화 이미지 저장용
            Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY); // 이미지를 회색조로 변환
            Cv2.GaussianBlur(gray, gray, new Size(7, 7), 2, 2); // 가우시안 블러를 적용하여 노이즈 감소

            // 오츠 알고리즘을 사용하여 이진화 수행
            Cv2.Threshold(gray, dst, 130, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);
            // 형태학적 변환 (Opening)을 적용하여 작은 잡음 제거
            Cv2.MorphologyEx(dst, dst, MorphTypes.Open, new Mat(), null, 1);
            return dst;
        }

        // 검출된 영역을 회전된 사각형으로 반환
        static List<RotatedRect> FindCoins(Mat img)
        {
            Point[][] contours; // 컨투어(외곽선)들을 저장할 배열
            HierarchyIndex[] hierarchy; // 계층 구조 정보 저장용
            // 외곽선을 찾기 위한 함수 호출
            Cv2.FindContours(img.Clone(), out contours, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            Mat col = new Mat();
            Cv2.CvtColor(img, col, ColorConversionCodes.GRAY2BGR); // 결과 시각화를 위한 컬러 이미지로 변환

            List<RotatedRect> circles = new List<RotatedRect>(); // 검출된 동전 영역 저장용
            foreach (var contour in contours)
            {
                RotatedRect rotatedRect = Cv2.MinAreaRect(contour); // 최소 영역의 회전된 사각형 계산
                float radius = (rotatedRect.Size.Width + rotatedRect.Size.Height) / 4.0f; // 동전 반지름 계산

                // 디버깅용 원 및 사각형 그리기 (주석 처리됨)
                // Cv2.Circle(col, rotatedRect.Center, 2, new Scalar(255, 0, 0), 2); // 중심점 표시
                // DrawRotatedRect(col, rotatedRect, new Scalar(0, 255, 0), 2); // 사각형 그리기
                // Cv2.ImShow("img", col); // 중간 결과 보기

                // 일정 크기 이상의 객체만 검출하기 위해 조건 설정
                if (radius > 18)
                    circles.Add(rotatedRect);
            }
            return circles; // 검출된 동전의 회전된 사각형 목록 반환
        }
        static void Main(string[] args)
        {
            int coinNo = 70; // 테스트할 동전 이미지 번호
            string fname = string.Format(@"c:/Temp/opencv/{0:D2}.png", coinNo); 
            Mat image = Cv2.ImRead(fname, ImreadModes.Color); // 이미지 읽기
            if (image.Empty()) 
            {
                Console.WriteLine("이미지를 불러올 수 없습니다.");
                return;
            }

            // 전처리 실행
            Mat thImg = Preprocessing(image); // 전처리된 이진화 이미지 생성
            List<RotatedRect> circles = FindCoins(thImg); // 동전 검출

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
