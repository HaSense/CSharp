using System;

namespace BasicClass02
{
    class Car
    {
        // 차량 브랜드 brand , 그랜저
        public string Brand;
        // year 년도
        public int Year;
        // 색상
        public string Color;
        // 속도 150km/h
        public int Speed;

        //달리다(run) -- 그랜저가 150km/h로 달린다.
        public void run()
        {
            Console.WriteLine($"{this.Brand}가 {this.Speed}km/h로 달린다");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car mycar = new Car();
            mycar.Brand = "그랜저";
            mycar.Color = "레드";
            mycar.Year = 2021;
            mycar.Speed = 150;

            mycar.run();
            Console.WriteLine($"색상 : {mycar.Color}, 년도 : {mycar.Year}");
        }
    }
}
