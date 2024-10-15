using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VecShow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 기본 선언 및 간결 방식
            Vec2i v1 = new Vec2i(5, 12);
            Vec3d v2 = new Vec3d(40, 130.7, 125.6);
            Vec2b v3 = new Vec2b(10, 10);
            //Vec6f v4 = new Vec6f(40f, 230.25f, 525.6f); //c#에서는 되도록 float는 사용하지 맙시다. Vec6d로 사용하세요.
            Vec3i v5 = new Vec3i(200, 230, 250);

            // 객체 연산 및 형변환
            //Vec3d v6 = v2 + (Vec3d)v5;
            Vec3d v6 = v2 + new Vec3d(v5.Item0, v5.Item1, v5.Item2);
            //Vec2b v7 = (Vec2b)v1 + v3;
            Vec2b v7 = new Vec2b((byte)v1.Item0, (byte)v1.Item1) + v3;

            // Point, Point3 객체 선언
            //Point pt1 = v1 + new Point(v7.Item0, v7.Item1);
            Point pt1 = new Point(v1.Item0, v1.Item1) + new Point(v7.Item0, v7.Item1);
            Point3i pt2 = new Point3i((int)v2.Item0, (int)v2.Item1, (int)v2.Item2);

            // 콘솔창 출력
            Console.WriteLine($"[v3] =  {v3}");
            Console.WriteLine($"[v7] =  {v7}");
            //Console.WriteLine($"[v3 * v7] =  {v3.Mul(v7)}");
            //안타깝지만 Mul이 없다. 직접 계산 ㅠㅠ
            Console.WriteLine($"[v3 * v7] =  ({v3.Item0 * v7.Item0}, {v3.Item1 * v7.Item1})");
            Console.WriteLine($"[v2] =  {v2}");
            Console.WriteLine($"[pt2] =  {pt2}");

            // 한글로 출력
            Console.WriteLine($"[v3] 값은 {v3} 입니다.");
            Console.WriteLine($"[v7] 값은 {v7} 입니다.");
            //Console.WriteLine($"[v3 * v7] 곱셈 결과는 {v3.Mul(v7)} 입니다.");
            //Mul이 없어 직접계산
            Console.WriteLine($"[v3 * v7] 곱셈 결과는 ({v3.Item0 * v7.Item0}, {v3.Item1 * v7.Item1}) 입니다.");
            Console.WriteLine($"[v2] 값은 {v2} 입니다.");
            Console.WriteLine($"[pt2] 값은 {pt2} 입니다.");
        }
    }
}
