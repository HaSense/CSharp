namespace LinqExam03
{
    //p624
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public Person(string name, int age, string address)
        {
            Name = name;
            Age = age;
            Address = address;
        }
        public override string ToString()
        {
            return string.Format($"{Name}{Age}{Address}");
        }
    }
    class MainLanguage
    {
        public string Name { get; set; }
        public string Language { get; set; }

        public MainLanguage(string name, string language)
        {
            Name = name;
            Language = language;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person("Tom", 63, "Korea"),
                new Person("Winnie", 40, "Tibet"),
                new Person("Anders", 47, "Sudan"),
                new Person("Hans", 25, "Tibet"),
                new Person("Eureka", 32, "Sudan"),
                new Person("Hawk", 15, "Korea")
            };

            List<MainLanguage> languages = new List<MainLanguage>
            {
                new MainLanguage("Anders", "Delphi"),
                new MainLanguage("Anders", "C#"),
                new MainLanguage("Tom", "Borland C++"),
                new MainLanguage("Hans", "Visual C++"),
                new MainLanguage("Winnie", "R")
            };

        }
    }
}

