using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamda_easy
{
    class Program
    {
        delegate int MyDelegate(int a, int b);
        
        class Calculator
        {
            public int Plus(int a, int b)
            {
                return a + b;
            }
            public int Minus(int a, int b)
            {
                return a - b;
            }
        }
        static void Main(string[] args)
        {
            Calculator Calc = new Calculator();
            MyDelegate Callback;

            Callback = new MyDelegate(Calc.Plus);
            Console.WriteLine(Callback(3, 4));

            Callback = (a, b) => a - b; //Minus
        }
    }
}
