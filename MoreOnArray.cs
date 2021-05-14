using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MoreOnArray
{
    class Program
    {
        private static bool CheckPassed(int score)
        {
            if (score >= 60)
                return true;
            return false;
        }
        private static void Print(int value)
        {
            Console.Write($"{value} ");
        }
        static void Main(string[] args)
        {
            int[] scores = new int[5] { 80, 74, 81, 90, 34 };

            foreach (int score in scores)
                Console.Write($"{score} ");
            Console.WriteLine();

            Array.Sort(scores);
            Array.ForEach<int>(scores, new Action<int>(Print));
            Console.WriteLine();

            Console.WriteLine($"Number of dimensions : {scores.Rank}");

            Console.WriteLine("Binary Search : 81 is at {0}",
                Array.BinarySearch<int>(scores, 81));
            Console.WriteLine("Linear Search : 90 is at {0}",
                Array.IndexOf(scores, 90));


            Console.WriteLine("Everyon passed ? : {0}",
                Array.TrueForAll<int>(scores, CheckPassed));


            int index = Array.FindIndex<int>(scores,
                delegate (int score)
                {
                    if (score < 60)
                        return true;
                    else
                        return false;
                });

            Console.WriteLine($"index value : {index}");

            scores[index] = 61;

            Console.WriteLine("Everyon passed ? : {0}",
                Array.TrueForAll<int>(scores, CheckPassed));

            Console.WriteLine($"Old length of scores : {scores.GetLength(0)}");

            /*배열의 크기변경 */
            Array.Resize<int>(ref scores, 10);
            Console.WriteLine($"Old length of scores : {scores.Length}");
            Array.ForEach<int>(scores, new Action<int>(Print));
            Console.WriteLine();

            Array.Clear(scores, 3, 7);
            Array.ForEach<int>(scores, new Action<int>(Print));
            Console.WriteLine();

            int[] sliced = new int[3];
            Array.Copy(scores, 0, sliced, 0, 3);
            Array.ForEach<int>(sliced, new Action<int>(Print));
            Console.WriteLine();
        }
    }
}
