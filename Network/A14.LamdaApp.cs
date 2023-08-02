using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaAppExam
{
    delegate int Calculate(int a, int b);
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            int sum = calculator.Add(100, 200);
            Console.WriteLine("Class : " + sum);

            //Delegate방식
            Calculate calculate = (int a, int b) => a + b;
            sum = calculate(100, 200);
            Console.WriteLine("Delegate : " + sum);

            //Func 방식
            Func<int, int, int> add = (a, b) => a + b;
            sum = add(100, 200);
            Console.WriteLine("Func : " + sum);

        }
    }
}
