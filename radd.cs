using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string snum1 = "12";
            
            char[] target1 = snum1.ToCharArray();
            Array.Reverse(target1);
            Console.WriteLine(target1); // 21
            string str1 = new String(target1);

            int a = Int32.Parse(str1);

            Console.WriteLine(a);   //21 (정수값)

            /* 결과 
             * 21
             * 21
             */
        }
    }
}
