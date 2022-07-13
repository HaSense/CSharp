using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTest04
{
    class Calculator
    {

    }
    class Computer
    {
        bool powerOn;
        public Computer()
        {
            powerOn = false;
        }
        public virtual void Boot() {
            Console.WriteLine("컴퓨터를 부팅하다.");
        }
        public void Shutdon() { }
        public void Reset() { }
    }
    class Notebook : Computer // , Calculator 다중상속은 안된다.
    {
        public override void Boot()
        {
            Console.WriteLine("노트북을 부팅하다.");
        }
    }
    class Desktop : Computer
    {
        public override void Boot()
        {
            Console.WriteLine("데스크탑을 부팅하다.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer();
            computer.Boot();

            Notebook notebook = new Notebook();
            notebook.Boot();

            Desktop desktop = new Desktop();
            desktop.Boot();


            Computer mycom = new Notebook();
        }
    }
}
