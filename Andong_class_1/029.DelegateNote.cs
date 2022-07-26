using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateNote
{
    internal class Program
    {
        delegate void SayPointer();

        static void Hello() => Console.WriteLine("Hello Developer");
        static void Main(string[] args)
        {
            SayPointer sayPointer = new SayPointer(Hello);
            sayPointer.Invoke();
        }
    }
}
