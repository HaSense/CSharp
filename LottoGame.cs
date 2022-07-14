using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoGame
{
    /*
    로또 게임 중복제거 확인
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] lotto_numbers = new int[45];
            int n;
            bool flag = false;
            
            for(int i=0; i<45; i++)
            {
                flag = false;
                n = random.Next(1, 46);
                for(int j=0; j<=i; j++)
                {
                    if (n == lotto_numbers[j])
                    {
                        i--;
                        flag = true;
                        break;
                    }
                }
                if (flag == false) 
                    lotto_numbers[i] = n;
            }

            Array.Sort(lotto_numbers);

            for (int i = 0; i < 45; i++)
            {
                Console.Write(lotto_numbers[i] + " ");
            }
            Console.WriteLine();

        }
    }
}
