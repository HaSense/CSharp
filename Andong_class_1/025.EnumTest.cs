using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enumTest
{
    enum Days { Sun=100, Mon, Tue, Wed, Thu, Fri, Sat}
    internal class Program
    {
        static void Main(string[] args)
        {
            int x1 = (int)Days.Sun;
            int x2 = (int)Days.Mon;
            int x3 = (int)Days.Tue;

            Console.WriteLine(x1);
            Console.WriteLine(x2);
            Console.WriteLine(x3);
        }
    }
}
