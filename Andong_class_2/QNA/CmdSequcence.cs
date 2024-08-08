namespace DynamicVariableApp
{
    

    internal class Program
    {
        delegate void CommandDelegate();
        static void Main(string[] args)
        {
            object cmd1=0, cmd2=1, cmd3=2;
            List<object> cmdList = new List<object>();

            cmdList.Add(cmd1);
            cmdList.Add(cmd2);
            cmdList.Add(cmd3);

            for(int i=0; i<3; i++)
            {
                Console.WriteLine(cmdList[i].ToString());
            }

            Console.WriteLine();
            Dictionary<string, object> cmdDict = new Dictionary<string, object>
            {
                { "cmd1", 0 },
                { "cmd2", 1 },
                { "cmd3", 2 }
            };

            foreach (var cmd in cmdDict)
            {
                Console.WriteLine($"{cmd.Key}: {cmd.Value.ToString()}");
            }


            //델리게이트 방식
            // 각 공정을 델리게이트로 정의
            CommandDelegate cmd5 = () => Console.WriteLine("공정 1 실행: 0");
            CommandDelegate cmd6 = () => Console.WriteLine("공정 2 실행: 1");
            CommandDelegate cmd7 = () => Console.WriteLine("공정 3 실행: 2");

            // 델리게이트 리스트에 추가
            List<CommandDelegate> cmdList2 = new List<CommandDelegate>
            {
                cmd5,
                cmd6,
                cmd7
            };

            // 모든 공정 실행
            foreach (var cmd in cmdList2)
            {
                cmd();
            }

        }

    }
}
