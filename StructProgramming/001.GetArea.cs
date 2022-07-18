using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Core_001
{
    class RectangleArea
    {
        public void Print2(int value)
        {
            Console.WriteLine(value);
        }
    }
    internal class Program
    {
        
        static void Print(int value)
        {
            Console.WriteLine(value);
        }
        static int InputWidth()
        {
            int width = Int32.Parse(Console.ReadLine());
            return width;
            
        }
        static int InputHeight()
        {
            int height = Int32.Parse(Console.ReadLine());
            return height;
        }
        static void Main(string[] args)
        {
            //1. 변수 선언 , 
            int width;
            int height;
            int area;
            //2.입력받기
            //width = Int32.Parse(Console.ReadLine());
            //height = Int32.Parse(Console.ReadLine());
            width = InputWidth();
            height = InputHeight();
            //3. 로직
            area = (width * height);
            //4. 출력
            Print(area);
            RectangleArea ra = new RectangleArea();
            ra.Print2(area);

        }
    }
}






