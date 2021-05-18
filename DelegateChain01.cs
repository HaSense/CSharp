using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateChain001
{
    class Program
    {
        delegate void ThereisAsFire(string location);
        static void Call119(string location)
        {
            Console.WriteLine("Call119");
        }
        static void ShotOut(string location)
        {
            Console.WriteLine("ShotOut");
        }
        static void Escape(string location)
        {
            Console.WriteLine("Escape");
        }
        static void Main(string[] args)
        {
            ThereisAsFire Fire = new ThereisAsFire(Call119);
            Fire += new ThereisAsFire(ShotOut);
            Fire += new ThereisAsFire(Escape);
            Fire -= new ThereisAsFire(ShotOut);


            Fire("우리집");
        }
    }
}
