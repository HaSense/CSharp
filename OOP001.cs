using System;

namespace OOP001
{
    class Dog
    {
        public string Name;
        public string Color;

        //default 생성자(Constructor)
        public Dog()
        {

        }
        //인자가 있는 생성자.
        public Dog(string Name, string Color)
        {
            this.Name = Name;
            this.Color = Color;
        }
        //메소드
        public virtual void Bark()
        {
            Console.WriteLine("멍멍!!");
        }
        //오버로딩
        public virtual void Bark(string direct)
        {
            Console.WriteLine($"{direct}뱡향을 향해 멍멍!!");
        }
    }
    class Chiwawa : Dog
    {
        //오버라이딩
        public override void Bark()
        {
            Console.WriteLine("왈왈!!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dog samy = new Dog(); //객체를 만들었습니다. 디폴트 생성자로 만듦
            samy.Name = "새미";
            samy.Color = "하얀색";
            samy.Bark();
            Console.WriteLine($"{samy.Name} : {samy.Color}");
            Console.WriteLine();

            Dog bomi = new Dog(Name: "보미", Color: "핑크색");
            bomi.Bark("동쪽");
            Console.WriteLine($"{bomi.Name} : {bomi.Color}");
            Console.WriteLine();

            Chiwawa kei = new Chiwawa();
            kei.Bark();


        }
    }
}
