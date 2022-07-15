using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 1. indexOf() - 문자, 문자열 찾기, 앞쪽에서 부터
             * 2. LastIndexOf() - 문자, 문자열 찾기 뒤에서
             * 3. StartsWith() - 현재 문자열이 지정된 문자열로 시작하는지 평가
             * 4. EndsWith() - 현재 문자열이 지정된 문자열로 끝나는지 평가
             * 5. Contains() - 문자열이 지정된 문자열을 포함하는지 평가
             * 6. Replace() - 문자, 문자열 변환, 치환
             */
            string greeting = "Good Morning";

            Console.WriteLine(greeting);
            Console.WriteLine();

            //실전
            Console.WriteLine($"Index of 'Good' : {greeting.IndexOf("Morning")}");
            Console.WriteLine($"Index of 'o' : {greeting.IndexOf('o')}");
            Console.WriteLine($"Index of 'Good' : {greeting.LastIndexOf("Good")}");

            //StartsWith()
            Console.WriteLine($"Starts With 'Good' : {greeting.StartsWith("Good")}"); //True
            Console.WriteLine($"{greeting.StartsWith("Morning")}"); //False

            //EndsWith()
            Console.WriteLine($"{greeting.EndsWith("Morning")}");

            //Contains
            Console.WriteLine($"{greeting.Contains("Good")}");

            //Replace()
            Console.WriteLine($"{greeting.Replace("Morning", "Evening")}");


            /*
             * ToLower() - 소문자로 변환
             * ToUpper() - 대문자로 변환
             * Insert() - 문자열 삽입
             * Remove() - 문자열 삭제
             * Trim() - 좌우 공백제어
             * TrimStart() - LTrim()
             * TrimEnd() - RTrim()
             */
            Console.WriteLine();
            Console.WriteLine($"{greeting.ToLower()}");
            Console.WriteLine($"{greeting.ToUpper()}");
            Console.WriteLine($"{greeting.Insert(5, "Day ")}");
            Console.WriteLine($"{greeting.Remove(0, 5)}");

            Console.WriteLine($"{"    Happy School     ".Trim()}");
            Console.WriteLine($"{"    Happy School".TrimStart()}");

            /* SubString - 지정된 위치로부터 지정된 수만큼 문자열 치환*/
            Console.WriteLine($"{"971204".Substring(0, 2)}");
            Console.WriteLine($"{"971204".Substring(2, 4)}");

        }
    }
}





