namespace TheadTest02_6_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(threadFunc);
            t.IsBackground = true; //Main 종료시 바로 종료됨
            t.Start();
            t.Join(); //Main스레드가 t를 기다려줍니다.

            Thread.CurrentThread.Name = "사장님";
            string mtName = Thread.CurrentThread.Name;
            Console.WriteLine($"{mtName} 프로그램 종료");
        }
        static void threadFunc()
        {
            Console.WriteLine("7초 후에 프로그램 종료");
            Thread.Sleep(7000);

            Thread.CurrentThread.Name = "개발부장";
            string mtName = Thread.CurrentThread.Name;
            Console.WriteLine($"{mtName} 프로그램 종료");
        }
    }
}
