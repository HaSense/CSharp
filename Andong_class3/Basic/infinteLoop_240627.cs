namespace LoopApp02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("다시 시작하겠습니까?");
                string word = Console.ReadLine();
                
                if (word.ToLower() == "n")
                {
                    Console.WriteLine("종료합니다");
                    break;
                }
                else if (word.ToLower() == "y")
                    continue;
                else
                    Console.WriteLine("단어를 새로 입력해 주세요");
            }
        }
    }
}
