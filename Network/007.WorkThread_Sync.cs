namespace WorkThread01
{
    internal class Program
    {
        // 동기화 객체
        private static readonly object lockObject = new object();
        static void Main(string[] args)
        {
            // 작업 스레드 수 설정
            int threadCount = 5;

            // 스레드 배열 생성
            Thread[] threads = new Thread[threadCount];

            // 각 스레드에 작업 할당
            for (int i = 0; i < threadCount; i++)
            {
                int threadIndex = i; // 로컬 변수로 인덱스를 캡처
                threads[i] = new Thread(() => DoWork(threadIndex));
                threads[i].Start();
            }

            // 모든 스레드가 작업을 마치기를 기다림
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("모든 작업이 완료되었습니다.");
        }
        // 각 스레드에서 수행할 작업 메서드
        static void DoWork(int index)
        {
            lock (lockObject)
            {
                Console.WriteLine($"스레드 {index} 시작: 작업을 수행 중...");
            }

            // 간단한 작업 시뮬레이션 (예: 1초 동안 대기)
            Thread.Sleep(1000);

            lock (lockObject)
            {
                Console.WriteLine($"스레드 {index} 완료: 작업이 끝났습니다.");
            }
        }
    }
}
