using System;


namespace OOP_005_core
{
    //객체지향 프로그래밍(OOP) 기본 단위 Class
    //클래스(Class) --> 패키지(Package) --> 프레임워크(Framework)
    //C# .NET Framework ==> PC, Enterprise, Device

    //OOP 1.캡슐화 class /멤버변수, 멤버메소드
    //    2.다형성(오버로딩, 오버라이딩)
    //    3.상속
    
    //추상클래스 , 개념적으로만 존재하고 main에서 생성되지 않는 클래스
    abstract class Shape
    {
        public Shape()
        {
            Console.WriteLine("Shape 생성자 호출");
        }
        public abstract void Draw();
    }
    class Triangle : Shape
    {
        public Triangle()
        {
            Console.WriteLine("Triangle 생성자 호출");
        }
        public override void Draw()
        {
            Console.WriteLine("삼각형을 그리다.");
        }
    }
    class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("삼각형을 그리다.");
        }
    }
    class Circle : Shape
    {
        public int radius;
        public Circle()
        {
            Console.WriteLine("Cirle 생성자 호출");
        }
        public override void Draw()
        {
            Console.WriteLine("원을 그리다.");
        }
        //오버로딩
        public virtual void Draw(int radius)
        {
            this.radius = radius;
            Console.WriteLine("반지름이 {0}인 원을 그리다.", this.radius);
        }
        
    }
    class Ellipse : Circle  //타원
    {

        public Ellipse()
        {
            Console.WriteLine("Ellipse 생성자 호출");
        }
        public override void Draw()
        {
            Console.WriteLine("타원을 그리다.");
        }

        public override void Draw(int radius)
        {
            Console.WriteLine("반지름이 {0}인 타원을 그리다.", radius);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //Shape shape = new Shape(); //Error가 정상 이유? 추상클래스
            //Triangle triangle = new Triangle();
            Ellipse ellipse = new Ellipse();
            ellipse.Draw();
            ellipse.Draw(5);
        }
    }
}
