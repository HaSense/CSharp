using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedParameter
{
    class Program
    {
        static void PrintProfile(string name, string phone, string addr)
        {
            Console.WriteLine($"Name:{name}, Phone:{phone}");
        }
        static void Main(string[] args)
        {

            //문법
            PrintProfile(name:"박찬호", phone: "010-333-3333", addr:"안동");
            PrintProfile("박찬호", phone: "010-333-3333", "안동");

            //속성을 모두 표현하면 순서가 변경되도 정상수행ㄴ
            PrintProfile(addr:"서울", name: "박지성", phone: "010-5555-5555");
            
            //속성이 모두 명명되지 않고 순서가 변경되면 에러발생
            //PrintProfile("박상현", "안동", phone: "010-333-3333"); //Error!!!
        }
    }
}
