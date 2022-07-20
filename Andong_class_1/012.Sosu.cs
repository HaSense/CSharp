using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SosuTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cnt = 0; // 나누어 떨어지는 수가 있는지 카운트
            for(int i= 2; i<=100; i++) //소수는 2부터 시작
            {
                cnt = 0; // 2 ~ 100 까지 진행하면서 항상 cnt를 0으로 초기화 해줌
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0) //약수가 생기면 카운트 증가
                    {
                        cnt++;
                        break; //카운트가 1개 라도 증가하면 더이상 소수가 아님, 따라서 다음 약수구하기는 의미없음. 루프를 중단시킴
                    }
                }
                if (cnt == 0)
                    Console.Write(i + " ");
            }

        }
    }
}
