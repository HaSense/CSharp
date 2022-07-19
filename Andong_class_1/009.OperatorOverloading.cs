using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    class Kilogram
    {
        //public double mass;
        public double Mass { get; set; }

        public Kilogram(double mass)
        {
            Mass = mass;
        }

        //연산자 오버로딩
        public static Kilogram operator +(Kilogram op1, Kilogram op2)
        {
            return new Kilogram(op1.Mass + op2.Mass);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Kilogram kg1 = new Kilogram(5);
            Kilogram kg2 = new Kilogram(10);

            Kilogram kg3 = kg1 + kg2;
            Console.WriteLine(kg3);
        }
    }
}
