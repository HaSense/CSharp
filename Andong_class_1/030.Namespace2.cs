using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Korea.Seoul;
using In = Korea.Incheon; //별명

namespace Korea
{
    namespace Seoul
    {
        public class Car
        {
            public void Run() => Console.WriteLine("서울 자동차가 달립니다.");
        }
    }
    namespace Incheon
    {
        public class Car
        {
            public void Run() => Console.WriteLine("인천 자동차가 달립니다.");
        }
    }
}

namespace DotNet_Core_030_Namspace_Using
{
    class Program
    {
        static void Main()
        {
            Korea.Seoul.Car s = new Korea.Seoul.Car();
            s.Run();

            Korea.Incheon.Car i = new Korea.Incheon.Car();
            i.Run();

            Car seoul = new Car();
            seoul.Run();

            In.Car ic = new In.Car();
            ic.Run();
        }
    }
}
