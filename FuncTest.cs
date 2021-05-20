using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncTest
{
    class Program
    {
        //Func 대리자 - 간단하게 무명함수 만들기 위해서~!!!
        static void Main(string[] args)
        {
            Func<int> func1 = () => 10;
            Console.WriteLine(func1());

            Func<int, int> func2 = (x) => x * 2;  // 4 * 2 = 8
            Console.WriteLine(func2(4));

            Func<double, double, double> func3 =
                (x, y) => x / y;
            Console.WriteLine(func3(22, 7));
        }
    }
}




