using System;

namespace BasicClass01
{
    class Cat           //설계도, 사용자 정의 타입
    {
        //1.멤버변수, 속성(atributes)
        public string Name;
        public string Color;
        public int age;
        //2.생성자
        public Cat(){ } //default 생성자
        //3.멤버메소드
        public void Meow()
        {
            Console.WriteLine($"{Name} : 야옹");
        }
    }
    class MainApp
    {
        static void Main(string[] args) //시간이 흐르는 RealWorld~!!!
        {
            Cat kitty; //reference
            kitty = new Cat(); //kitty 객체(Object), Instance
            kitty.Name = "키티";
            kitty.Color = "하얀색";
            kitty.age = 1;
            kitty.Meow();
            Console.WriteLine($"{kitty.Name} : {kitty.Color}");
            //키티의 나이를 1살로 하고 출력은 다음과 같이 하라
            //"키티 : 1 "
            Console.WriteLine($"{kitty.Name} : {kitty.age}");

            Cat nero = new Cat();
            //이름:네로 색깔:검은색 나이:17살
            nero.Name = "네로";
            nero.Color = "검은색";
            nero.age = 17;
            nero.Meow();
            Console.WriteLine($"{nero.Name} : {nero.Color}");
            Console.WriteLine($"{nero.Name} : {nero.age}");
        }
    }
}
