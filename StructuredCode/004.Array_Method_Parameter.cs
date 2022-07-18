using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Core_004
{
    class Calculator
    {
        public int[] intputting(int[] score)
        {
            for (int i = 0; i < 4; i++)
            {
                score[i] = Int32.Parse(Console.ReadLine());
                //score[0]
                //score[1]
                //score[2]
                //score[3]
            }
            return score;
        }
        public double excuteAvg(int[] score)
        {
            int sum = 0;
            for(int i=0; i<4; i++)
            {
                sum += score[i];
            }
            double avg = sum / 4.0;
            
            return Math.Round(avg, 2);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] score = new int[4];   //배열선언

            Calculator calc = new Calculator();
            score = calc.intputting(score);    //매개변수로 배열 ---> 배열의 이름(포인터)        

            double avg = calc.excuteAvg(score);
            Console.WriteLine(avg);
        }
    }
}
