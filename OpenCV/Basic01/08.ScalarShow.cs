using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalarShow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Scalar red = new Scalar(0, 0, 255);  // Scalar_<uchar>
            Scalar blue = new Scalar(255, 0, 0); // Scalar_<int>
            Scalar color1 = new Scalar(500.0);   // Scalar_<double>
            Scalar color2 = new Scalar(100.0f, 200.0f, 125.9f);

            Vec3d green = new Vec3d(0, 0, 300.5);
            Scalar green1 = new Scalar(
                color1.Val0 + green.Item0,
                color1.Val1 + green.Item1,
                color1.Val2 + green.Item2,
                color1.Val3);  

            Scalar green2 = new Scalar(
                color2.Val0 + green.Item0,
                color2.Val1 + green.Item1,
                color2.Val2 + green.Item2,
                color2.Val3);  

            // 결과 출력
            Console.WriteLine($"blue = {blue.Val0}, {blue.Val1}, {blue.Val2}");
            Console.WriteLine($"red =  {red}");
            Console.WriteLine($"green =  {green}");
            Console.WriteLine($"green1 =  {green1}");
            Console.WriteLine($"green2 =  {green2}");

            // 한글로 결과 출력
            Console.WriteLine($"blue 값은 {blue.Val0}, {blue.Val1}, {blue.Val2} 입니다.");
            Console.WriteLine($"red 값은 {red} 입니다.");
            Console.WriteLine($"green 값은 {green} 입니다.");
            Console.WriteLine($"green1의 값은 {green1} 입니다.");
            Console.WriteLine($"green2의 값은 {green2} 입니다.");
        }
    }
}
