using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Core_exam001
{
    class Calculrator
    {
        public int InputValueCalculate()
        {
            int N = Int32.Parse(Console.ReadLine());
            return N;
        }
        public int LogicCalculate(int N)
        {
            int sum = 0;
            for (int i = 1; i <= N; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 입력을 받은 정수까지 합을 프로그램을 작성하시오.
            // N? 100
            // 5050
            // Calculrator의 기능 메소드로 만들어 주세요.
            // 1. 입력 (변수입력)
            // 2. 로직 --> Loop 메소드
            // 3. 출력 --> 메소드. 

            Calculrator calculrator = new Calculrator();

            int N = calculrator.InputValueCalculate();
            int sum = 0;
            
            sum = calculrator.LogicCalculate(N);

            Console.WriteLine(sum);

        }
    }
}
