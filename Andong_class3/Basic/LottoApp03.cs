using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoApp03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            HashSet<int> lottoNumbers = new HashSet<int>();

            while (lottoNumbers.Count < 6)
            {
                int number = random.Next(1, 46);
                lottoNumbers.Add(number);
            }//로또번호 6개 만들기 끝

            //보너스번호
            int bonusNumber;
            do
            {
                bonusNumber = random.Next(1, 46);
            }while (lottoNumbers.Contains(bonusNumber));

            //출력
            //로또번호
            foreach (int number in lottoNumbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            //보너스
            Console.WriteLine($"보너스 번호 : " + bonusNumber);

        }
    }
}
