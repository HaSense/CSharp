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
            return Int32.Parse(Console.ReadLine());
            
        }
        static int InputHeight()
        {
            return Int32.Parse(Console.ReadLine());
        }
        static void InputVariablet(ref int w, ref int h)
        {
            w = Int32.Parse(Console.ReadLine());
            h = Int32.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            //1. 변수 선언 , 
            int width = 0;
            int height = 0;
            int area;
            //2.입력받기
            //width = Int32.Parse(Console.ReadLine());
            //height = Int32.Parse(Console.ReadLine());
            //width = InputWidth();
            //height = InputHeight();
            InputVariablet(ref width, ref height);

            //3. 로직
            area = (width * height);
            //4. 출력
            Print(area);
            RectangleArea ra = new RectangleArea();
            ra.Print2(area);

        }
    }
}






