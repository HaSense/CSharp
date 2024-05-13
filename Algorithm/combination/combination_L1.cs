using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combination_L1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3 };
            int r = 2; //선택할 원소 수

            List<int> combination = new List<int>();
            List<List<int>> result = new List<List<int>>();

            Combine(nums, combination, result, 0, r); // 0 is int start

            foreach(var i in result)
            {
                System.Console.WriteLine($"[{string.Join(", ", i)}]");
            }
        }
        static void Combine(int[] nums, List<int> combination, List<List<int>> result, int start, int r)
        {
            if(r == 0)
            {
                result.Add(new List<int>(combination));
                return;
            }

            for(int i= start; i<=nums.Length - r; i++) 
            {
                combination.Add(nums[i]);
                Combine(nums, combination, result, i + 1, r - 1);
                combination.RemoveAt(combination.Count - 1);
            }

        }
    }
}
