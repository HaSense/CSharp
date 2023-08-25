using System.Text.RegularExpressions;

namespace StringTokenCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "2023-08-24 입금 5,000,000원 2023-08-23 출금 1,000,000원";
            //Console.WriteLine(str);

            // 날짜 형식을 찾아 앞에 줄바꿈 문자를 추가합니다.
            string pattern = @"(\d{4}-\d{2}-\d{2})";
            string replaced = Regex.Replace(str, pattern, "\n$1");

            // 수정된 문자열을 출력합니다.
            Console.WriteLine(replaced.Trim()); // Trim()을 사용하여 앞쪽의 불필요한 줄바꿈을 제거합니다.
        }
    }
}