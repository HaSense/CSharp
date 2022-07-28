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
        static void threadFunc()
        {
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}");

            //Thread t = new Thread(new ThreadStart(threadFunc));
            Thread t = new Thread(threadFunc);
            t.Start();
            
            //threadFunc();
        }
        

    }
}
