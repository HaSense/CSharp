using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_QUIZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100];
            int tmp = 0;
            bool flag = false;
            Random random = new Random();
            for(int i=0; i<arr.Length; i++)
            {
                flag = false;
                tmp = random.Next(1, 101);
                for(int j=0; j<=i; j++)
                {
                    if (arr[j] == tmp)//중복된 값
                    {
                        i--;
                        flag = true;
                        break;
                    }
                }
                if(flag == false)
                    arr[i] = tmp;
            }
            //Array.Sort(arr);
            

            IEnumerable<int> arr2 = from i in arr
                                    where i >= 75 && i <= 95
                                           && i % 5 ==0
                                    orderby i
                                    select i;

            foreach (int i in arr2)
            {
                Console.Write(i + " ");
            }
        }
    }
}
