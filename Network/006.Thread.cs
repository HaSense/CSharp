
namespace ThreadOut
{
    internal class Program
    {
        static void threadFunc()
        {
            Console.WriteLine("5초후 종료");
            Thread.Sleep(10000);
            Console.WriteLine("스레드 종료");
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(threadFunc));
            t.IsBackground = true; //이곳을 주석처리 했을 때와 안했을 때를 비교
            t.Start();
            Console.WriteLine("메인스레드 종료");
        }
    }
    
}
