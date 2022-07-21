//.Net Core 9.0 문법으로 작성해 보았습니다.

using System
using System.Collections;

namespace CorePrj001
{
    class Car
    {
        private string[] names;
        public Car(int length)
        {
            names = new string[length];
        }
        public string this[int index]
        {
            get { return names[index]; }
            set { names[index] = value; }
        }
        public IEnumerator GetEnumerator()
        {
            return names.GetEnumerator();
        }
    }
    class IndexerTest
    {
        static void Main()
        {
            Car cars = new Car(3);

            cars[0] = "CLA";
            cars[1] = "KIA";
            cars[2] = "BMW";

            foreach(string name in cars)
            {
                Console.WriteLine(name);
            }

        }
    }
}
