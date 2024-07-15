namespace UsingList01
{
    class Person
    {
        public string name;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            * 1. 일반 배열과 리스트 비교
            * 2. 일반 기본타입과 객체타입 사용 시 비교
            */
          
            string[] arr = new string[3] { "홍길동", "이순신", "강감찬"};
            List<char> list = new List<char>();
            list.Add('X'); list.Add('Y'); list.Add('Z');

            Person[] persons = new Person[2];
            Person p1 = new Person();
            p1.name = "홍길동";
            persons[0] = p1;
            Person p2 = new Person();
            p2.name = "이순신";
            persons[1] = p2;

            List<Person> list2 = new List<Person>();
            Person p3 = new Person();
            p3.name = "홍길동";
            list2.Add(p3);

            Person p4 = new Person();
            p4.name = "이순신";
            list2.Add(p4);

            foreach (Person p in list2)
            {
                Console.WriteLine(p.name);
            }
        }
    }
}
