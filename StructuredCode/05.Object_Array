using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Core_009_Property
{
    public class Student
    {
        private string name;
        //private string stnum;
        public string Stnum { get; set; }  //propery
        //private string pnum;
        public string Pnum { get; set; } //propery
        //private string address;
        public string Address { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student();
            Student[] students = new Student[3];

            st1.Name = "홍길동";
            st1.Stnum = "221234567";
            st1.Pnum = "010-1111-1111";
            st1.Address = "경상북도 안동시 정하동 200";

            //Student hong = new Student();

            students[0] = st1;
            //Student st2 = new Student();
            //students[1] = st2;
            students[1].Name = "홍길순";
            students[1].Stnum = "221234568";
            students[1].Pnum = "010-2222-2222";
            students[1].Address = "경상북도 안동시 정하동 100";

            Console.WriteLine(students[0].Name);
            Console.WriteLine(students[1].Name);

        }
    }
}










