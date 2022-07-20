using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VriableArgument
{
    internal class Program
    {
        /*
         * int total [0]
         * total = Sum(1, 2)
         * total = Sum(1, 2, 3)
         * total = Sum(1, 2, 3, 4, 5);
         */
        static int Sum(params int[] args)
        {
            int sum = 0;

            for(int i=0; i<args.Length; i++)
            {
                if (i > 0)
                    Console.Write(",");
                Console.Write(args[i]);

                sum += args[i];
            }
            Console.WriteLine();
            return sum;
        }
        static void Main(string[] args)
        {
            int sum = Sum(1, 2, 3);
            Console.WriteLine(sum);
        }
    }
}
