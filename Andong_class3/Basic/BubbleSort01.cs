using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortApp01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //오름차순 버블정렬
          
            int[] list = { 4, 5, 7, 3, 2, 1, 9, 8 };
            //Array.Sort(arr);
            int temp;
            for(int i= list.Length - 1; i>0; i--)
            {
                for(int j=0; j<i; j++)
                {
                    if (list[j] > list[j+1])
                    {
                        //교환조건 이루어짐
                        temp = list[j];
                        list[j] = list[j+1];
                        list[j+1] = temp;
                    }
                }
            }
            foreach(int i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}
