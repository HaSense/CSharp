using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddMagicSquare_simple
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int y=0, x=n/2;
            int cnt=1;
            int[, ] arr = new int[n, n];


            
            while(cnt <= n*n) //cnt가 1 ~ N*N일때까지 반복
            { 
                //값을 입력합니다.
                arr[y, x] = cnt;

                if (cnt % n == 0) //테이블에 들어간 수가 n의 배수이면 행만 증가
                    y++;
                else
                {
                    y--;            //기본 증가
                    x++;            //기본 증가
                    if (y < 0)      //행이 첫 행보다 작아지는 경우는 행을 마지막해으로 둠
                        y = n - 1;
                    if (x > (n - 1)) //열이 끝 열을 넘어가는 경우 열은 첫 열로 맞추어 준다.
                        x = 0;

                }
                cnt++;              //카운트 변수 증가
            }


            //마방진 모양 출력
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{arr[i, j],5}");
                }
                Console.WriteLine();
            }
        }
    }
}
