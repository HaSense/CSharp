using System;
using System.Threading;

namespace AbortingThread
{
    class SlideTask
    {
        int count;

        public SlideTask(int count)
        {
            this.count = count;
        }

        public void KeepAlive()
        {
            while (true)
            {
                try
                {
                    while (count > 0)
                    {
                        Console.WriteLine($"{count--} left");
                        Thread.Sleep(10);
                    }
                    Console.WriteLine("Count : 0");
                }
                catch (ThreadAbortException e)
                {
                    Console.WriteLine(e);
                    Thread.ResetAbort(); // 스레드 Abort() 취소
                }
                finally
                {
                    Console.WriteLine("리소스 정리...");
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SlideTask task = new SlideTask(100);
            Thread t1 = new Thread(task.KeepAlive);
            t1.IsBackground = true;

            Console.WriteLine("스레드 시작...");
            t1.Start();

            Thread.Sleep(100);

            Console.WriteLine("스레드 멈춤...");
            t1.Abort();

            Console.WriteLine("스레드 종료까지 기다림...");
            t1.Join();

            Console.WriteLine("Main 종료.");
        }
    }
}
