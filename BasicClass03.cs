using System;

namespace BasicClass03
{
    class Program
    {   
        class Cat
        {
            //생성자, 객체의 초기화를 담당한다.
            //생성자는 한개 이상 만들 수 있다.
            public Cat()
            {
                Name = "야옹이";
                Color = "누런색";
            }
            //인자가 있는 생성자
            public Cat(string _Name, string _Color)
            {
                Name = _Name;
                Color = _Color;
            }
            //멤버메소드

            //멤버변수
            public string Name;
            public string Color;
        }
        static void Main(string[] args)
        {
            Cat kitty = new Cat();
            kitty.Name = "키티";  //객체 초기화, 값 할당
            Console.WriteLine($"{kitty.Name} : {kitty.Color}");

            //인자가 있는 생성자
            Cat nero = new Cat("네로", "검은색");
            Console.WriteLine($"{nero.Name} : {nero.Color}");
        }
    }
}
