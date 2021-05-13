using System;

namespace abstractClass
{
    abstract class Shape
    {
        public abstract void Draw();
    }
    class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("사각형을 그리다.");
        }
    }
    class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("삼각형을 그리다.");
        }
    }
    class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("원을 그리다.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Shape shape = new Shape(); //Error 발생
            Circle c = new Circle();
            c.Draw();
        }
    }
}
