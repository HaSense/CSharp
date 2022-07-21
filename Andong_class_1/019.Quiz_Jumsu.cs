using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] score = new int[10] { 1, 0, 1, 1, 1, 0, 0, 1, 1, 0 };
            int N = Int32.Parse(Console.ReadLine());
            int[] score = new int[N];

            string input_str = Console.ReadLine();
            string[] input_split_arr = input_str.Split(' ');

            score = Array.ConvertAll(input_split_arr, i => Int32.Parse(i));


            int cnt = 0;
            int jumsu = 0;
            for(int i=0; i<score.Length; i++)
            {
                if (score[i] != 0)
                {
                    jumsu += ++cnt;
                }
                else
                {
                    cnt = 0;
                }
            }
            Console.WriteLine(jumsu);   
        }
    }
}
