namespace OOP06
{
    class Shape
    {
        //멤버변수
        private string color;
        public string Color { get; set; }       //Property

        public void SetColor(string color)
        {
            this.color = color;
        }
        public string GetColor()
        {
            return this.color;
        }

        public virtual void Draw()
        {
            Console.WriteLine("도형을 그리다.");
        }
    }
    class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("원을 그리다.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle();
            circle.SetColor("파란색");
            Console.WriteLine(circle.GetColor());
            circle.Color = "노란색";
            Console.WriteLine(circle.Color);
            
        }
    }
}
