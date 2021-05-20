using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_exam2
{
    class Person
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //배우 5명의 Person배열
            Person[] arrPerson =
            {
                new Person(){Name="정우성", Height=186 },
                new Person(){Name="김태희", Height=158 },
                new Person(){Name="고현정", Height=172 },
                new Person(){Name="이문세", Height=178 },
                new Person(){Name="하동훈", Height=171 }
            };
            //키가 170이상인 배우만 모여있는 List를 만들어 봅시다.
            var result = from person in arrPerson
                         where person.Height > 170
                         orderby person.Name descending   //오름차순, 내림차순
                         select person;

            foreach (Person p in result)
                Console.WriteLine($"{p.Name} :{p.Height}");
        }
    }
}
