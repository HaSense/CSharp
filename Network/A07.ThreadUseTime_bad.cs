using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ThreadUsingTime
{
    class Program
    {
        static void Main(string[] args)
        {
            const long numberCount = 1_000_000_00; // 연산을 수행할 횟수

            // 단일 스레드 경우
            Stopwatch sw = new Stopwatch(); // 실행 시간을 측정하기 위한 Stopwatch 객체 생성
            sw.Start(); // 시간 측정 시작
            for (long i = 0; i < numberCount; i++)
            {
                var result = i * i; // 간단한 연산 수행
            }
            sw.Stop(); // 시간 측정 종료
            Console.WriteLine($"단일 스레드로 실행한 경우 소요 시간: {sw.ElapsedMilliseconds}ms");

            // 멀티 스레드 경우
            sw.Reset(); // Stopwatch 초기화
            sw.Start(); // 시간 측정 시작
            Parallel.For(0, numberCount, i =>
            {
                var result = i * i; // 간단한 연산 수행
            });
            sw.Stop(); // 시간 측정 종료
            Console.WriteLine($"멀티 스레드로 실행한 경우 소요 시간: {sw.ElapsedMilliseconds}ms");
        }
    }

}
