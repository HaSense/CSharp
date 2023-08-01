using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSyncApp01
{
    class Counter
    {
        public int count = 0;
        private readonly object thisLock = new object();
        public void Increase()
        {
            lock (thisLock)
            {
                int temp = count;
                Thread.Sleep(1);
                count = temp + 1;
            }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            Thread[] t = new Thread[500];

            for(int i=0; i<500; i++)
            {
                t[i] = new Thread(counter.Increase);
                t[i].Start();
            }
            for(int i=0; i<500; i++)
            {
                t[i].Join();
            }
            
            Console.WriteLine(counter.count);
        }
    }
}
