using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Core_014_Delegate_369
{
    delegate void EventHandler(string message); //매개변수가 있는 델리게이트

    class MyNotifier
    {
        public event EventHandler SomthingHappend;
        public void DoSomething(int number)
        {
            int temp = number % 10;

            if( temp != 0 && temp % 3 == 0)
            {
                SomthingHappend(String.Format("{0} : 짝", number));
            }
        }
    }

    internal class Program
    {
        public static void MyHandler(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            MyNotifier notifier = new MyNotifier();
            notifier.SomthingHappend += new EventHandler(MyHandler);

            for(int i=1; i<30; i++)
            {
                notifier.DoSomething(i);
            }
        }
    }
}
