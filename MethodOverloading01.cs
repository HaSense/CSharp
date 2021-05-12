using System;

//객체지향
//클래스 --> 멤버변수, 생성자, 메소드 
//오버로딩(Overloading), 오버라이딩(Overriding)

namespace MethodOverloading01
{
    class Calculator
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }
        public int Plus(int a, int b, int c)
        {
            return a + b + c;
        }
        public double Plus(double a, double b)
        {
            return a + b;
        }
        public double Plus(int a, double b)
        {
            return a + b;
        }
    }
    class MainClass
    {
        static void Main(string[] args)
        {
            Calculator myCal = new Calculator();
            Console.WriteLine(myCal.Plus(5, 7));
            Console.WriteLine(myCal.Plus(5, 7, 8));
            Console.WriteLine(myCal.Plus(1.0, 2.4));
            Console.WriteLine(myCal.Plus(1, 2.4));
        }
    }
}
