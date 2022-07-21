using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> st = new Stack<int>();

            st.Push(11);
            st.Push(22);
            st.Push(33);

            Console.WriteLine("마지막에 저장된 데이터 : " + st.Peek());

            Console.WriteLine(st.Pop()); //11, 22

            if(st.Contains(11))
                Console.WriteLine("요소가 존재합니다.");

            st.Clear();

            if (st.Contains(11))
                Console.WriteLine("요소가 존재합니다.");
            else
                Console.WriteLine("요소가 없습니다.");

        }
    }
}
