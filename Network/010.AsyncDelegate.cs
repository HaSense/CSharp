using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDelegateTest
{   //비동기 델리게이트 스레드 기법
    class Calculator
    {
        public int GetArea(int width, int height)
        {
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}");

            int area = width * height;
            return area;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //델리게이트와 비동기 객체를 사용하여 스레드 구현
            Calculator calculator = new Calculator();
            Func<int, int, int> work = calculator.GetArea;

            //사용 --> 스레드 생성
            IAsyncResult asynRes = work.BeginInvoke(10, 20, null, null);

            //메인스레드 동작상태를 확인해 봅시다. 실행되고 있다면 1을 출력합니다.
            Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}");
            
            //스레드로 부터 값 리턴
            int result = work.EndInvoke(asynRes);
            Console.WriteLine(result);

        }
    }
}
