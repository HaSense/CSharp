using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltegateCallBackTest
{
    delegate int GetResultDelegate();
    class Target
    {
        public void Do(GetResultDelegate getResult) 
        {
            Console.WriteLine(getResult()); //콜백메소드 호출
        }
    }
    class Source
    {
        public int GetResult()  //콜백 용도로 전달될 메서드
        {
            return 10;
        }
        public int GetResult2()
        {
            return 500;
        }
        public void Test()
        {
            Target target = new Target();
            target.Do(new GetResultDelegate(this.GetResult));
            target.Do(new GetResultDelegate(this.GetResult2));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Source src = new Source();
            Console.WriteLine(src.GetResult());
            src.Test();
        }
    }
}
