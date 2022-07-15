using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Total : {0, 7:D}", 123);
            Console.WriteLine("Total : {0, -7:D}", 123);

            string result = string.Format("{0}", "ABC");
            Console.WriteLine(result);
            result = string.Format("{0}DEF", "ABC");
            Console.WriteLine(result);
            result = string.Format("{0, -10}DEF", "ABC");
            Console.WriteLine(result);

            Console.WriteLine();
            //Format 연습
            string fmt = "{0, -20}{1, -15}{2, 30}";

            Console.WriteLine(fmt, "Publisher", "Author", "Title");
            Console.WriteLine(fmt, "Marvel", "Stan Lee", "Iron Man");
            Console.WriteLine(fmt, "Prentice Hall", "K&R", "The C Programming");

            Console.WriteLine();
            //숫자 서식화
            //10진수
            Console.WriteLine("{0:D}", 255);
            Console.WriteLine("{0:D}", 0xFF);
            //16진수
            Console.WriteLine("{0:X}", 255);
            Console.WriteLine("{0:X}", 0xFF);
            //숫자에 콤마(,)를 삽입니다.
            Console.WriteLine("{0:N}", 123456789);
            //고정 소수점 형식
            Console.WriteLine("{0:F}", 123.45);
            Console.WriteLine("{0:F5}", 123.456);
            //지수
            Console.WriteLine("{0:E}", 123.456789);
        }
    }
}






