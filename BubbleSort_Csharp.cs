using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 6, 2, 9, 8, 3, 4, 7 };

            int temp;

            for(int i=0; i<7; i++)
            {
                for(int j=0; j<7-1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                Console.Write("{0}단계 : ", i + 1);
                foreach (int a in arr)
                    Console.Write(a + " ");
                Console.WriteLine();
            }
            Console.Write("최종 단계 : ");
            foreach (int i in arr)
                Console.Write(i + " ");
            Console.WriteLine(); 
        }
    }
}
