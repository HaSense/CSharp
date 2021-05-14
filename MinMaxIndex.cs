using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 22, 55, 99, 77, 45, 89, 11 };
            int Max = int.MinValue;
            int index = 0;
            for(int i=0; i<arr.Length; i++)
            {
                if(arr[i] > Max)
                {
                    index = i;
                    Max = arr[i];
                }
            }
            Console.WriteLine("Max Index : {0}", index);
            Console.WriteLine("Max Value: {0}", 99);
        }
    }
}
