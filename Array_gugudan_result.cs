using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_gugudan_result
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] result_gugudan = new int[72];
            //cnt변수
            int cnt = 0;
            for(int i=2; i<=9; i++)
            {
                for(int j=1; j<=9; j++)
                {
                    result_gugudan[cnt++] =  i* j;
                }
            }//배열에 값등록
            //출력
            for(int i=0; i<result_gugudan.GetLength(0); i++)
            {
                Console.Write(result_gugudan[i]+" ");
            }
        }
    }
}
