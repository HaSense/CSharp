using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dn = new Dictionary<int, string>();

            dn.Add(1, "Jeff Bezos");
            dn.Add(2, "Larry Page");
            dn.Add(3, "Mark Zuckerbeg");
            dn.Add(4, "Warren Buffett");

            Console.WriteLine("자료의 개수 : " + dn.Count);

            dn.Remove(4);
            foreach(int i in dn.Keys)
            {
                Console.WriteLine(dn[i]);
            }

            foreach(string s in dn.Values)
            {
                Console.WriteLine(s);
            }

        }
    }
}
