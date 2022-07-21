using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> li = new List<string>(); //배열 --> 리스트
            Console.WriteLine("현재 리스트의 크기 : " + li.Capacity);
            Console.WriteLine("현재 리스트의 요소 개수 : " + li.Count);

            li.Add("James");
            li.Add("Andrew");
            li.Add("George");
            li.Add("Donald");
            li.Add("John");
            li.TrimExcess(); //배열 메모리 낭비 제거 ~!!!

            li.Add("Susan"); li.Add("Louisa");
            li.Add("Dolley"); li.Add("Clara");
            li.Add("Ansel"); li.Add("Grace");

            //요소제거
            li.Remove("Ansel");
            li.RemoveAt(0);

            li.Insert(0, "Tom");

            //li.InsertRange(0, li);
            li.Sort();

            foreach(string item in li)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("현재 리스트의 크기 : " + li.Capacity);
            Console.WriteLine("현재 리스트의 요소 개수 : " + li.Count);
        }
    }
}
