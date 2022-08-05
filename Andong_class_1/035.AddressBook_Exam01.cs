using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBApp01
{
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Pnumber { get; set; }

        public Student(int id, string name, string pnumber)
        {
            ID = id;
            Name = name;
            Pnumber = pnumber;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            Student st = new Student(1, "홍길동", "010-1111-1111");
            students.Add(st);
            st = new Student(2, "강호동", "010-2222-2222");
            students.Add(st);


            Console.WriteLine($"{"순번" ,-10}{"이름", -15}{"전화번호", -15}");
            foreach (Student s in students)
            {
                Console.WriteLine($"{s.ID, -10}{s.Name, -15}{s.Pnumber, -15}");
            }

        }
    }
}
