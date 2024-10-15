using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RectShow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Size2d, Point2f 선언
            Size2d sz = new Size2d(100.5, 60.6);
            Point2f pt1 = new Point2f(20f, 30f);
            Point2f pt2 = new Point2f(100f, 200f);

            // Rect 객체 기본 선언 방식
            Rect rect1 = new Rect(10, 10, 30, 50);
            Rect2f rect2 = new Rect2f(pt1.X, pt1.Y, pt2.X - pt1.X, pt2.Y - pt1.Y);
            Rect2d rect3 = new Rect2d(new Point2d(20.5, 10), sz);

            // 간결 선언 방식 & 연산 적용
            Rect rect4 = rect1 + new Point(pt1.X, pt1.Y);
            Rect2f rect5 = rect2 + new Size2f((float)sz.Width, (float)sz.Height);
            Rect2d rect6 = new Rect2d(rect1.X, rect1.Y, rect1.Width, rect1.Height).Intersect(new Rect2d(rect2.Left, rect2.Top, rect2.Width, rect2.Height));

            // 결과 출력
            Console.WriteLine($"rect3 = {rect3.X}, {rect3.Y}, {rect3.Width}x{rect3.Height}");
            Console.WriteLine($"rect4 시작점 = {rect4.Location}, 끝점 = ({rect4.Right}, {rect4.Bottom})"); // 수정된 부분
            Console.WriteLine($"rect5 크기 = {rect5.Width}x{rect5.Height}"); // 수정된 부분
            Console.WriteLine($"[rect6] = {rect6}");

            // 한글로 결과 출력
            Console.WriteLine($"rect3 = {rect3.X}, {rect3.Y}, {rect3.Width} x {rect3.Height} 크기");
            Console.WriteLine($"rect4의 시작점 = {rect4.Location}, 끝점 = ({rect4.Right}, {rect4.Bottom})");
            Console.WriteLine($"rect5의 크기 = {rect5.Width}x{rect5.Height}");
            Console.WriteLine($"rect6의 교차 영역 = {rect6}");

        }
    }
}
