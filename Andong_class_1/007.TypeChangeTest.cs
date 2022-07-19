using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeChangeTest
{
    class Computer
    {
        public void On()
        {
            Console.WriteLine("컴퓨터 켜기");
        }
    }
    class NoteBook : Computer
    {
        public void NoteBookTurnOn()
        {
            Console.WriteLine("노트북 켜기");
        }
        public void NoteBookTurnOff()
        {
            Console.WriteLine("노트북 끄기");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //형변환 연습
            Computer com1 = new Computer(); //문제없음
            NoteBook nb1 = (NoteBook)com1; //문법은 문제없음

            nb1.NoteBookTurnOn(); // 컴파일에는 문제가 없으나 런타임에서 에러가 발생

            Computer com2 = new NoteBook();
            //com2.NoteBookTurnOn();(사용불가) // --> com2는 자식클래스의 메소드가 보이지 않는다.
            NoteBook nb2 = (NoteBook)com2;
            nb2.NoteBookTurnOn();


        }
    }
}
