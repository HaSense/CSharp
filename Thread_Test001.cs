using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Test001
{

    class Program
    {
        static void DoSomething1()
        {
            for(int i=0; i<500; i++)
            {
                Console.WriteLine("DoSomething : {0}", i+1);
            }
        }
        static void DoSomething2()
        {
            for (int i = 600; i < 1000; i++)
            {
                Console.WriteLine("DoSomething : {0}", i + 1);
            }
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(DoSomething1));
            Thread t2 = new Thread(new ThreadStart(DoSomething2));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine("메인 프로그램을 종료합니다.");
        }
    }
}
