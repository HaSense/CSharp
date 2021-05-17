using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack(); //LIFO Last in First out

            string str = Console.ReadLine();
            char[] chArr = str.ToCharArray();

            foreach (char c in chArr)
                stack.Push(c);

            while (stack.Count > 0)
                Console.Write(stack.Pop());
        }
    }
}






