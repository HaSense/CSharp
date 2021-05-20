using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatementLamda
{
    delegate void DoSomething();
    delegate string Concatenate(string[] args);

    class Program
    {
        static void Main(string[] args)
        {
            DoSomething DoIt = () =>
            {
                Console.WriteLine("동작을 합니다~!!!");
            };

            DoIt();

            Concatenate concat = (arr) =>
            {
                string result = "";
                foreach (string s in arr)
                    result += s;

                return result;
            };
            
            Console.WriteLine(concat(args));
        }
    }
}
