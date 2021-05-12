using System;

namespace LocalFunction
{
    class Program
    {
        static string ToLowerString(string input)
        {
            var arr = input.ToCharArray();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = ToLowerChar(i);
            }
            char ToLowerChar(int i)
            {
                if (arr[i] < 'A' || arr[i] > 'Z')
                    return arr[i];
                else
                    return (char)(arr[i] + 32);
            }
        
            return new string(arr);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ToLowerString("Hello!"));
            Console.WriteLine(ToLowerString("Good Morning"));
            Console.WriteLine(ToLowerString("This is C#"));
        }
    }
}
