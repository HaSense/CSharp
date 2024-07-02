namespace ThePreludeOfBrave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerName;
            int choice;

            Console.Write("용감한 탐험가의 이름을 입력하세요: ");
            playerName = Console.ReadLine();

            Console.WriteLine("\n안녕하세요, 용감한 탐험가 " + playerName + "!\n");

            do
            {
                Console.WriteLine("메뉴 선택:");
                Console.WriteLine("1. 낡은 마을 탐험");
                Console.WriteLine("2. 숲 속 오두막 방문");
                Console.WriteLine("3. 게임 종료");
                Console.Write("선택: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // 낡은 마을 탐험 내용
                        Console.WriteLine("플레이어가 낡은 마을에 도착합니다.");
                        Thread.Sleep(500);
                        Console.WriteLine("마을 주민들과 대화하고, 마을의 비밀을 파헤칠 수 있는 단서를 얻습니다.");
                        Thread.Sleep(500);
                        Console.WriteLine("마을의 문제를 해결하기 위해 퀘스트를 수행해야 할 수도 있습니다.");
                        Thread.Sleep(500);
                        Console.WriteLine("퀘스트를 완료하면 보상을 받을 수 있습니다.");
                        Thread.Sleep(500);
                        break;
                    case 2:
                        // 숲 속 오두막 방문 내용
                        Console.WriteLine("플레이어가 숲 속 오두막에 도착합니다.");
                        Thread.Sleep(500);
                        Console.WriteLine("오두막에는 은둔하는 마법사가 살고 있습니다.");
                        Thread.Sleep(500);
                        Console.WriteLine("마법사로부터 새로운 기술을 배우거나, 아이템을 구입할 수 있습니다.");
                        Thread.Sleep(500);
                        Console.WriteLine("마법사는 플레이어의 여정에 중요한 조언을 해줄 수도 있습니다.\r\n\r\n");
                        Thread.Sleep(500);
                        break;
                    case 3:
                        Console.WriteLine("게임을 종료합니다.");
                        break;
                    default:
                        Console.WriteLine("잘못된 선택입니다.");
                        break;
                }
            } while (choice != 3);
        }
    }
}
