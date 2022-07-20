using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDirect01
{
    internal class Program
    {
        static void Greet() => Console.WriteLine("인사하다");
        static void Greet_eng() => Console.WriteLine("Good Morning!");
        static void Greet_jpn() => Console.WriteLine("곤니지와~!");
        static void Greet_chn() => Console.WriteLine("니하오!");
        delegate void GreetBot();
        static void Main(string[] args)
        {
            //Greet(); // 직접실행
            //GreetBot tomi = new GreetBot(Greet);
            GreetBot tomi = Greet;
            tomi += Greet_eng;
            tomi += Greet_jpn;
            tomi += Greet_chn;

            //tomi += delegate () { Console.WriteLine("반갑습니다."); };
            //tomi += () => { Console.WriteLine("어서오세요."); };
            //tomi.Invoke();
            tomi();
        }
    }
}
