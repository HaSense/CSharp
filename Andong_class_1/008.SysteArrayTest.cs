using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemArrayTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 7, 6 };
            int[,] arr2 = new int[2, 2] {
                {1, 2 },
                {3, 4 }
            };

            Console.WriteLine($"arr의 차원 : {arr.Rank}");    //배열의 차원을 가져오는 변수
            Console.WriteLine($"arr2의 차원 : {arr2.Rank}"); 

            Array.Sort(arr);
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();    

            for(int i=0; i< arr.Length; i++)
            {
                Console.Write(arr.GetValue(i) + " ");   // c#에서 사용하는 배열요소에 메소드로 접근하는 방법
            }
            Console.WriteLine();

            int[] arr3 = new int[7];
            Array.Copy(arr, arr3, 7); // c#에서 사용하는 배열 복사

            foreach (int i in arr3)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
