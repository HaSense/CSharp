using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReaderTest
{
    //지역변수 전역변수 영역(Scope) 테스트 해 보세요.
    internal class Program
    {
        static int a = 0;
        static int Function(int b)
        {
            a = b + 100; 
            return a;
        }
        static void Main(string[] args)
        {
            a = 100;

            a = Function(a);
            
            Console.WriteLine(a); //

            
        }
    }
}
