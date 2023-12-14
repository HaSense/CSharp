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
    
    /*
      코드를 보면 Car 클래스가 직접 Engine 클래스의 인스턴스를 생성한다.
      이는 Car 클래스가 Engine 클래스에 강하게 결합되어 있다는 것을 의미
      강연결성을 느슨한 연결로 변경할 필요가 있는 코드이다.
    */
    public class Car
    {
        private Engine _engine;
        public Car(Engine engine)
        {
            _engine = engine;
        }
        public void Drive()
        {
            _engine.Start("엔진이 시작됩니다.");
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
