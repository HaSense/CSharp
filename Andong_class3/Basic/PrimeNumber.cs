using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //변수를 도구처럼 사용할 수 있어야 한다~!!!!
            bool flag = false; // flag변수

            for (int i=2; i<=100; i++)
            {
                for(int j=2; j<i; j++)
                {
                    if(i % j == 0)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                    Console.Write($"{i} ");
                flag = false;
            }
            Console.WriteLine();
        }
    }
}
