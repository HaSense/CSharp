using System;

namespace MyApp_ref_test1
{
    class Program
    {
        struct Numbers
        {
            public int a;
            public int b;
            public int c;
            public int d;
            public int e;
        };
        static void Main(string[] args)
        {
            int i = 1;
            int r = 2;
            int o = 100;
            int r2 = 3;

            Numbers n = new Numbers();
            n.a = 1;
            n.b = 2;
            n.c = 3;
            n.d = 4;
            n.e = 5;

            RefTest(i, ref r, out o, in r2, in n);
            Console.WriteLine(o);//100
        }
        static void RefTest(int i, ref int r, out int o, in int ro, in Numbers num)
        {
            r += 100 + ro;
            o = 100;
            //ro = 200;
            int sum = num.a + num.b;
        }
    }
}
