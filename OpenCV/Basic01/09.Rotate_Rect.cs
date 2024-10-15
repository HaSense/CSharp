using OpenCvSharp;
using OpenCvSharp.Flann;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVSharp_RotateRect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat image = new Mat(300, 500, MatType.CV_8UC3, new Scalar(255, 255, 255));

            // 중심점과 크기 및 각도로 RotatedRect 생성
            Point2f center = new Point2f(250, 150);
            Size2f size = new Size2f(300, 100);
            RotatedRect rotRect = new RotatedRect(center, size, 20);  // 각도를 20도로 설정

            // rotRect의 꼭짓점 가져오기
            Point2f[] pts = rotRect.Points();

            // 회전된 사각형 그리기
            for (int i = 0; i < 4; i++)
            {
                // Point2f를 Point로 변환
                Point p1 = new Point((int)pts[i].X, (int)pts[i].Y);
                Point p2 = new Point((int)pts[(i + 1) % 4].X, (int)pts[(i + 1) % 4].Y);

                // 꼭짓점을 잇는 선 그리기
                Cv2.Line(image, p1, p2, new Scalar(0), 2); 
            }

            // 회전된 사각형의 중심에 원 그리기
            Cv2.Circle(image, new Point((int)rotRect.Center.X, (int)rotRect.Center.Y), 4, new Scalar(0), -1);  

            // BoundingRect를 사용해 내접 사각형 그리기 (내접은 회전되지 않음)
            Rect boundRect = rotRect.BoundingRect();
            Cv2.Rectangle(image, boundRect, new Scalar(0), 1); 

            Cv2.ImShow("회전 사각형", image);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
