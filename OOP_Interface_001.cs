using System;

namespace OOP_Interface_001
{
    //상속 은 is - a
    class Horse
    { 
    }
    class Angel
    {

    }
    interface IWing
    {
        public void fly();
        //interface에 만들어진 메소드는 무조건 자식클래스에서
        //구현되어야 한다.
    }
    class Unicon : Horse, IWing
    {
        public void fly()
        {
            Console.WriteLine("날다");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Unicon mery = new Unicon();
            mery.fly();
        }
    }
}
