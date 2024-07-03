namespace OOPApp04
{
  /*
  * 오버라이딩, 추상(abstarct)클래스 샘플 예제.
  */
    abstract class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("도형을 그리다.");
        }
    }
    class Triangle : Shape
    {
        //Draw() Overriding 하세요.  삼각형을 그리다.
        public override void Draw()
        {
            Console.WriteLine("삼각형을 그리다.");
        }
    }
    class Rectangle : Shape
    {
        //Draw() Overriding 하세요. 사각형을 그리다.
        public override void Draw()
        {
            Console.WriteLine("사각형을 그리다.");
        }
    }
    class Circle : Shape
    {
        //Draw() Overriding 하세요. 원을 그리다.
        public override void Draw()
        {
            Console.WriteLine("원을 그리다.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Shape shape = new Shape();
            Triangle triangle = new Triangle();
            Rectangle rectangle = new Rectangle();
            Circle circle = new Circle();

            triangle.Draw();
            rectangle.Draw();
            circle.Draw();
        }
    }
}
