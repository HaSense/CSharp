namespace DelegateApp01
{
    //Delegate
    //Code119
    internal class Program
    {
        //delegate 선언
        delegate void PrintDelegate(string str);
        class Print
        {
            public void PrintOut(string str)
            {
                Console.WriteLine(str);
            }
        }
        static void Main(string[] args)
        {
            Print p = new Print();
            PrintDelegate pdg = p.PrintOut;
            pdg("안녕하세요");
        }
    }
}
