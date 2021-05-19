using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD_001
{
    
    class Program
    {
        //알고리즘 : 유클리드호제법
        //최대공약수
        static int gcd(int a, int b)
        {
            int temp, n;
            if( a< b)
            {
                temp = a;
                a = b;
                b = temp;
            }
            
            //값 = a(제수) % b(피제수)
            // a = b
            // b = 값
            // 나머지가 없을 때 까지 반복
            while (b != 0)
            {
                n = a % b;
                a = b;
                b = n;
            }
            return a;
        }
        //최소공배수
        static int lcm(int x, int y)
        {
            return (x * y) / gcd(x, y);     //최대공약수
        }
        static void Main(string[] args)
        {
            int result_gcd, result_lcm;
            result_gcd = gcd(4, 6);
            result_lcm = lcm(4, 6);

            Console.WriteLine(result_gcd);
            Console.WriteLine(result_lcm);
        }
    }
}
