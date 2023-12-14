using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DICode
{
    public interface IEngine
    {
        string Start();
    }
    public class Engine : IEngine
    {
        public string Start()
        {
            return "엔진이 시작됩니다.";
        }
    }
    /*
      이런 형태로 만들면 IEngine 인터페이스를 구현하는 다른 클래스들도 Car 클래스에
      쉽게 주입할 수 있습니다.
      
      Engine클래스가 변경되어도 Car 클래스는 항상 고정됩니다.

      예) DieselEngine, ElectricEngine, LPIEngine
    */
    
    public class Car
    {
        private IEngine _engine;
        public Car(IEngine engine)
        {
            _engine = engine;
        }
        public string Drive()
        {
            return _engine.Start();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            Car car = new Car(engine);
            Console.WriteLine(car.Drive());
        }
    }
}
