using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionTest
{
    //Action, Func, Predicate
    //Action 대리자 : 반환값이 없는 메서드를 대신 호출합니다.
    //Func 대리자 : 매개변수와 반환값이 있는 메서드를 호출합니다.
    //Predicate 대리자 : T 매개변수에 대한 bool값을 반환하는 메서드를 대신 호출합니다.
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> printf = Console.WriteLine;
            printf.Invoke("메서드 대신 호출");
            printf("메서드 대신 호출");

            Func<int, int> abs = Math.Abs;
            Console.WriteLine(abs(-500));

            Func<double, double, double> pow = Math.Pow;
            Console.WriteLine(pow(2, 10));

            Func<string, string> toLower = str => str.ToLower();
            Console.WriteLine(toLower("LamdaExpression"));

            Func<int, int> anonymous = delegate (int x) { return x * x; };
            Console.WriteLine(anonymous(2));

            Func<int> getNumber1 = delegate () { return 1234; };
            Console.WriteLine(getNumber1());

            Func<int> getNumber2 = () => 1234;
            Console.WriteLine(getNumber2());

            Func<int, int> addOne1 = delegate (int x) { return x + 1; };
            Console.WriteLine(addOne1(10));
            Func<int, int> addOne2 = x => x + 1;
            Console.WriteLine(addOne2(10));

            Func<string, string, string> plus1 = delegate (string a, string b) { return $"{a} {b}"; };
            Console.WriteLine(plus1("Hello", "World"));


            Predicate<string> isNullOrEmpty = String.IsNullOrEmpty;
            Console.WriteLine(isNullOrEmpty("Not Null"));

            Predicate<Type> isPrimitive = t => t.IsPrimitive;
            Console.WriteLine(isPrimitive(typeof(string)));

        }
    }
}










