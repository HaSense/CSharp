using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Core_031_InitObject
{
    class Person
    {
        //private string name;
        //private int age;
        public string Name { get; set; } = "홍길동";//Property
        public int Age { get; set; } = 1; //초기값 설정

        public Person()
        {

        }
        public Person(string name, int age)
        {
            Name = name; 
            Age = age;
        }
    }
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        static void Main()
        {
            Person p1 = new Person();
            Console.WriteLine($"{p1.Name} : {p1.Age}");
            Person p2 = new Person("이순신", 45);
            Console.WriteLine($"{p2.Name} : {p2.Age}");

            //자동속성을 이용한 객체 멤버 초기화
            var customer = new Customer { Id = 1, Name = "강감찬", City = "개성" };
            //customer.Id = 1;
            //customer.Name = "강감찬";
            //customer.City = "개성";
            Console.WriteLine(customer.Name);
            Console.WriteLine(customer.GetType());
        }
    }
}   
