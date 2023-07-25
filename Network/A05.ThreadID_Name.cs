using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadApp01
{
    
    internal class Program
    {
        static void DoSomething()
        {
            for (int i = 1; i < 1000; i++) { };
            
            Console.WriteLine($"스레드 정보:{Thread.CurrentThread.ManagedThreadId}:" +
                $"{Thread.CurrentThread.Name}");
        }
        static void Print()
        {
            Console.WriteLine($"스레드 정보:{Thread.CurrentThread.ManagedThreadId}:" +
                $"{Thread.CurrentThread.Name}");
        }
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            Console.WriteLine($"스레드 정보:{Thread.CurrentThread.ManagedThreadId}:" +
                $"{Thread.CurrentThread.Name}");
            Print();
            Thread t = new Thread(new ThreadStart(DoSomething));
            t.Name = "Thread-1";
            t.Start();
        }
    }
}
