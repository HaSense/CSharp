using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList_Test01
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList만들기, 크기에 따라 메모리 크기가 증가감하는 자료구조, 배열과 유사하다~!!!!
            ArrayList list = new ArrayList();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            //list.Remove(20);
            list.RemoveAt(1);

            list.Insert(1, 25); //1번째 매개변수 : index 2번째 매개변수: value

            foreach (int i in list)
                Console.WriteLine(i);
        }
    }
}
