using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rank1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int N = 5;
            int[] arr = new int[N] { 97, 65, 84, 84, 91};

            var rankings = arr.Select(s => new { 
                Score = s, Rank = arr.Where(i => i > s).Count() + 1 });

            foreach(var r in rankings)
            {
                Console.WriteLine($"{r.Score} {r.Rank}");
            }
        }
    }
}
