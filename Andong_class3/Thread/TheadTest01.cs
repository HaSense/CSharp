namespace ThreadTest01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(threadFunc1);
            Thread t2 = new Thread(threadFunc2);
            
            t1.Start();
            t2.Start();
        }
        static void threadFunc1()
        {
            for(int i=1; i<=100; i++)
                Console.WriteLine(i);
        }
        static void threadFunc2()
        {
            char c1 = 'A', c2 = 'a';
            for(int i=1; i<26; i++)
                Console.WriteLine((char)c1++);
            for (int j = 1; j < 26; j++)
                Console.WriteLine((char)c2++);
        }
    }
}
