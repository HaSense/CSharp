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
