using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerTest002
{
    class Developer
    {
        private string name;
        public string this[int index]
        {
            get { return name; }
            set { name = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var developers = new Developer();
            developers[0] = "이순신";
            Console.WriteLine(developers[0]);

            developers[1] = "강감찬";
            Console.WriteLine(developers[1]);

        }
    }
}
