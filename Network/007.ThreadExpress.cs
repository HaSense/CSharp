using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExpress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(Run));
            t1.Start();

            Thread t2 = new Thread(Run);
            t2.Start();

            Thread t3 = new Thread(delegate ()
            {
                Run();
            });
            t3.Start();

            Thread t4 = new Thread( () => Run() );
            t4.Start();

            //익명
            new Thread(() => Run()).Start();
        }
        
        static void Run()
        {
            Console.WriteLine("Run 메소드가 동작합니다.");
        }
    }
}
