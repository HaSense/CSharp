using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest001
{
    internal class Program
    {
        static void threadFunc1()
        {
            //알파벳 A ~ Z && a ~ z
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}");

            for (int i = 'A'; i <= 'Z'; i++)
                Console.WriteLine((char)i);
            for (int i = 'a'; i <= 'z'; i++)
                Console.WriteLine((char)i);

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: 스레드 종료!!!");
        }
        static void threadFunc2()
        {
            // 1 ~ 100까지 출력
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}");

            for (int i = 1; i <= 100; i++)
                Console.WriteLine(i);

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} 스레드 종료!!!");
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}");
            //스레드를 만들어서 동작시켜 주세요.
            Thread t1 = new Thread(new ThreadStart(threadFunc1));
            Thread t2 = new Thread(new ThreadStart(threadFunc2));
            t1.Start();
            t2.Start();

            t1.Join(); //메인스레드가 타 스레드가 모두 종료될 때까지 기다려 줍니다.
            t2.Join();

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} 스레드 종료!!!");
        }
        

    }
}
