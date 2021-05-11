using System;

namespace Function_RADD
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(); //문자열 배열의 요소를 공백을 기준으로 잘라준다.
            char[] num1 = arr[0].ToCharArray(); //문자열 배열을 char형 배열로 변경해 준다
            char[] num2 = arr[1].ToCharArray(); //즉, Type을 변경하였다.
            Array.Reverse(num1); //Array.Reverse함수는 return 타입이 없는 void 형이다.
            Array.Reverse(num2); //

            int sum = int.Parse(num1) + int.Parse(num2);
            string s_sum = sum.ToString(); //정수를 문자열로 변경 
            char[] c_sum = s_sum.ToCharArray();
            Array.Reverse(c_sum);//char 배열을 뒤집는다, Reverse 함수는 배열을 뒤집는 함수라 
                                 //문자열이 매개변수로 오면 동작하지 않는다.
            Console.WriteLine(c_sum); 

        }
    }
}
