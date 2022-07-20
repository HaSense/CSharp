using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Core_016_LocalMethod02
{
    
    internal class Program
    {
        public static string ToLowerString(string input)
        {
            var arr = input.ToCharArray();
            for(int i=0; i<arr.Length; i++)
            {
                arr[i] = ToLowerChar(i);
            }

            //Local Method
            char ToLowerChar(int i)
            {
                if (arr[i] < 'A' || arr[i] > 'Z')
                    return arr[i];
                else
                    return (char)(arr[i] + 32); //대문자 A + 32 ---> a
            }

            return new string(arr);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ToLowerString("Hello"));
            Console.WriteLine(ToLowerString("Good Morning"));
            Console.WriteLine(ToLowerString("This is C#"));
        }
    }
}
