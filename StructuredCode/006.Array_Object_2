using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Core_010_Arary_Object
{
    class Car
    {
        public string Brand { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car[] cars = new Car[3];
            //Car c1 = new Car();
            //cars[0] = c1;
            cars[0] = new Car(); //익명할당
            cars[1] = new Car();
            cars[2] = new Car();
            cars[0].Brand = "현대";
            cars[1].Brand = "BMW";
            cars[2].Brand = "벤츠";

            foreach(Car car in cars)
            {
                Console.WriteLine(car.Brand);
            }

            for(int j=0; j<3; j++)
            {
                Console.WriteLine(cars[j].Brand);
            }
        }
    }
}

