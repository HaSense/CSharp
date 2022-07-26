using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer001
{
    class Catalog
    {
        //인덱서
        public string this[int index]
        {
            get
            {
                return (index % 2 == 0) ? $"{index} : 짝수변환" : $"{index} : 홀수변환";
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            Console.WriteLine(catalog[0]);
            Console.WriteLine(catalog[1]);
            Console.WriteLine(catalog[2]);
        }
    }
}
