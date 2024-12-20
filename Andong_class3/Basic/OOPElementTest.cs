namespace OOPElementTest
{
    /*
     * 상속, 오버로딩, 오버라이딩 활용 연습
     */
    public class Car
    {
        public virtual void Drive()
        {
            Console.WriteLine("자동차가 운전되고 있습니다.");
        }
        public void Refuel(int liters)
        {
            Console.WriteLine($"자동차에 {liters} 리터의 연료를 주입했습니다.");
        }

        public void Refuel(string fuelType)
        {
            Console.WriteLine($"자동차에 {fuelType} 연료를 주입했습니다.");
        }
    }
    public class Bus : Car
    {
        public override void Drive()
        {
            Console.WriteLine("버스가 운전되고 있습니다.");
        }
    }

    public class Taxi : Car
    {
        public override void Drive()
        {
            Console.WriteLine("택시가 운전되고 있습니다.");
        }
    }

    public class Truck : Car
    {
        public override void Drive()
        {
            Console.WriteLine("트럭이 운전되고 있습니다.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Bus bus = new Bus();
            Taxi taxi = new Taxi();
            Truck truck = new Truck();

            car.Drive();
            bus.Drive();
            taxi.Drive();
            truck.Drive();

            car.Refuel(50);
            car.Refuel("디젤");
        }
    }
//[출력결과]
//자동차가 운전되고 있습니다.
//버스가 운전되고 있습니다.
//택시가 운전되고 있습니다.
//트럭이 운전되고 있습니다.
//자동차에 50 리터의 연료를 주입했습니다.
//자동차에 디젤 연료를 주입했습니다.
}
