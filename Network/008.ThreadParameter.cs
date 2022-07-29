using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadParameter2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(Run));
            t1.Start();

            Thread t2 = new Thread(new ParameterizedThreadStart(Calc));
            t2.Start(10.00);

            Thread t3 = new Thread(() => Sum(10, 20, 30));
            t3.Start();

        }
        static void Run()
        {
            Console.WriteLine("Run()");
        }
        static void Calc(Object radius)
        {
            double r = (double)radius;
            double area = r * r * Math.PI;
            Console.WriteLine($"r={r}, area={area : 0.000}");
        }
        static void Sum(int d1, int d2, int d3)
        {
            int sum = d1 + d2 + d3;
            Console.WriteLine(sum);
        }
    }
}
