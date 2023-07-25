using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadProgrammingExam
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch(); // 실행 시간을 측정하기 위한 Stopwatch 객체 생성
            int numberOfTasks = 10; // 수행할 작업의 수

            // 단일 스레드 경우
            sw.Start(); // 시간 측정 시작
            for (int i = 0; i < numberOfTasks; i++)
            {
                DoWork(i); // 작업 실행
            }
            sw.Stop(); // 시간 측정 종료
            Console.WriteLine($"단일 스레드로 실행한 경우 소요 시간: {sw.ElapsedMilliseconds}ms");

            // 멀티 스레드 경우
            sw.Reset(); // Stopwatch 초기화
            sw.Start(); // 시간 측정 시작
            Thread[] threads = new Thread[numberOfTasks]; // 작업 수만큼의 스레드 배열 생성
            for (int i = 0; i < numberOfTasks; i++)
            {
                int taskNum = i; // 현재 작업 번호
                threads[i] = new Thread(() => DoWork(taskNum)); // 새 스레드 생성 및 작업 할당
                threads[i].Start(); // 스레드 시작
            }
            foreach (Thread thread in threads)
            {
                thread.Join(); // 모든 스레드가 종료될 때까지 대기
            }
            sw.Stop(); // 시간 측정 종료
            Console.WriteLine($"멀티 스레드로 실행한 경우 소요 시간: {sw.ElapsedMilliseconds}ms");
        }

        static void DoWork(int taskNumber)
        {
            // 시간이 소요되는 작업을 시뮬레이션
            Thread.Sleep(500); // 500ms 동안 대기
            Console.WriteLine($"작업 {taskNumber} 완료.");
        }
    }

}
