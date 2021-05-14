using System;

namespace Array_001
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1
                = new string[3] { "안녕", "Hello", "Halo" };
            
            string[] array2
                = new string[] { "안녕", "Hello", "Halo" };
            
            string[] array3
                = { "안녕", "Hello", "Halo" };

            int[] array4 = { 1, 2, 3 }; //선언 OK~!!! 


            for (int i = 0; i < array1.Length; i++)
                Console.WriteLine(array1[i]);

            foreach (string s in array2)
                Console.WriteLine(s);

            foreach (int n in array4)
                Console.WriteLine(n);

            //10.3 System.Array
            Console.WriteLine($"array1 Type : {array1.GetType()}");
            Console.WriteLine($"Base type of array : {array1.GetType().BaseType}");

            int a = 100;
            Console.WriteLine($"a Type : {a.GetType()}");
            Console.WriteLine($"Base type of a : {a.GetType().BaseType}");

            byte b = 1;
            Console.WriteLine($"a Type : {b.GetType()}");
            Console.WriteLine($"Base type of a : {b.GetType().BaseType}");

            double d = 3.14;
            Console.WriteLine($"a Type : {d.GetType()}");
            Console.WriteLine($"Base type of a : {d.GetType().BaseType}");
        }
    }
}
