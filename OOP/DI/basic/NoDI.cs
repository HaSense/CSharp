using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoDICode
{
    public class Engine
    {
        public void Start(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class Car
    {
        private Engine _engine;
        public Car(Engine engine)
        {
            _engine = engine;
        }
        public void Drive()
        {
            _engine.Start("차가 달립니다.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            Car car = new Car(engine);
            car.Drive();
        }
    }
}
