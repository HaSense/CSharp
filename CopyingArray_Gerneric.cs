using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyingArray
{
    class Program
    {
        //함수추가
        static void CopyArray<T>(T[] source, T[] target)
        {
            for(int i=0; i<source.Length; i++)
            {
                target[i] = source[i];
            }
        }

        static void Main(string[] args)
        {
            //1.int[] test
            int[] source = { 1, 2, 3, 4, 5 };
            int[] target = new int[source.Length];
            CopyArray<int>(source, target);
            foreach (int e in target)
                Console.WriteLine(e);

            //2.string[] test
            string[] source2 = { "하나", "둘", "셋", "넷", "다섯" };
            string[] target2 = new string[source2.Length]; //5개
            CopyArray<string>(source2, target2);
            foreach (string e in target2)
                Console.WriteLine(e);

            //3.double[] test
            double[] source3 = { 3.14, 1.47, 107.55, 77.1234, 100.77 };
            double[] target3 = new double[source3.Length]; //5개
            CopyArray<double>(source3, target3);
            foreach (double e in target3)
                Console.WriteLine(e);
            //4.char[] test
            char[] source4 = { 'A','B','C','D','E' };
            char[] target4 = new char[source4.Length]; //5개
            CopyArray<char>(source4, target4);
            foreach (char e in target4)
                Console.WriteLine(e);
        }
    }
}
