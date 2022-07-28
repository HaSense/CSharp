using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest02
{
    class Car
    {
        public void Run()
        {
            Console.WriteLine("차가 달리다~~~!!!");
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Thread t = new Thread(new ThreadStart(car.Run));
            t.Start();
        }
    }
}
