using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lotto = new int[7];
            Random random = new Random();
            int n = random.Next(1, 46);
            bool flag = false;          
            for(int i=0; i<7; i++)
            {
                n = random.Next(1, 46);
                for (int j=0; j>i; j++)
                {
                    if(n == lotto[j])
                    {
                        flag = true;
                        break;
                    }
                        
                }//end of for_j
                if (flag == false)
                    lotto[i] = n;
                else{
                    
                    i--;
                }
                    
            }

            int bonus = lotto[0];
            int[] lastLotto = new int[6];
            Array.Copy(lotto, 1, lastLotto, 0, 6);
            Array.Sort(lastLotto);
            for(int i=0; i<6; i++)
            {
                Console.Write(lastLotto[i] + " ");
            }
            Console.WriteLine("\n보너스 번호 : " + lotto[0]);
        }
    }
}
