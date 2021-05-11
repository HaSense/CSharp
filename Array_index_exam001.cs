using System;

namespace Array_index_exam001
{
    //배열의 기수값 연습
    //1 3 5 7 9
    //2 4 6 8 10
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            for(int i=0; i<10;i++)
            {
                arr[i] = (i + 1);
                if(i%2==0)
                {
                    Console.Write(arr[i] + " ");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 1)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }
}
