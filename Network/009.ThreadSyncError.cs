using System;
using System.Threading;

class Program
{
    static int sharedValue = 0;

    static void Main(string[] args)
    {
        Thread incrementThread = new Thread(Increment);
        Thread decrementThread = new Thread(Decrement);

        // 스레드 시작
        incrementThread.Start();
        decrementThread.Start();

        // 스레드가 종료되기를 기다림
        incrementThread.Join();
        decrementThread.Join();

        Console.WriteLine($"최종 값: {sharedValue}");
    }

    static void Increment()
    {
        for (int i = 0; i < 100000; i++)
        {
            sharedValue++;
        }
    }

    static void Decrement()
    {
        for (int i = 0; i < 100000; i++)
        {
            sharedValue--;
        }
    }
}
