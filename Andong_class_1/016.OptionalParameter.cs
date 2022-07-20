using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionalParameterTest
{
    internal class Program
    {
        //선택적인수 문법
        static void PrintProfile(string name="홍길동", string phone = "010-0000-0000")
        {
            Console.WriteLine($"Name:{name}, Phone:{phone}");
        }
        static void Main(string[] args)
        {
            PrintProfile();
            PrintProfile("강호동");
            PrintProfile("유재석", "010-1111-1111");
            PrintProfile(name: "신동엽");
            PrintProfile(name: "이순신", phone: "010-3333-3333");
        }
    }
}
