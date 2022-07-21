using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> qu = new Queue<char>(); //큐객체 생성

            qu.Enqueue('A');
            qu.Enqueue('B');
            qu.Enqueue('C');

            Console.WriteLine("큐 요소 개수 : "+ qu.Count);
            Console.WriteLine("큐 마지막 값 : " + qu.Peek());

            Console.WriteLine("첫번재 출력값 : " + qu.Dequeue()); //FIFO
            qu.TrimExcess();

            qu.Clear();//큐 데이터 다 지움
        }
    }
}
