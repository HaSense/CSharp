namespace OOPTest05
{
    class Person        //명사, 대문자로 시작!
    {
        //1.멤버 변수
        //private string name;
        //private int age;

        //Property
        public string Name{ get; set; }
        public int Age{ get; set; }

        //2.생성자 , 1개 이상
        public Person() //default 생성자
        {
        }
        public Person(string name)
        {
            Name = name;
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        //3.멤버메소드
        public void Eat()
        {
            Console.WriteLine($"밥을 먹습니다.");
        }
        public void Eat(string food)
        {
            Console.WriteLine($"{food}를 먹습니다.");
        }

        //Getter, Setter
        //public string GetName()
        //{
        //    return Name;
        //}
        //public void SetName(string name)
        //{
        //    this.name = name;
        //}
        //public int GetAge()
        //{
        //    return age;
        //}
        //public void SetAge(int age)
        //{
        //    this.age = age;
        //}
        
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person tom = new Person();
            tom.Eat();
            tom.Eat("오렌지");
            //Console.WriteLine(tom.GetName());
            Console.WriteLine(tom.Name);

            Person sam = new Person("Sam");
            //Console.WriteLine(sam.GetName());
            //Console.WriteLine(sam.GetAge());
            Console.WriteLine(sam.Name);
            Console.WriteLine(sam.Age);

            Person tony = new Person("Tony", 24);
            //Console.WriteLine(tony.GetName());
            //Console.WriteLine(tony.GetAge());
            Console.WriteLine(tony.Name);
            Console.WriteLine(tony.Age);
        }
    }
}
