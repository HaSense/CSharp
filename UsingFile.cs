using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = File.Create("c:\\Temp\\Test1\\a.dat");
            string path1 = "c:\\Temp\\Test1\\a.dat";
            string path2 = "c:\\Temp\\Test1\\b.dat";

            fs.Close();

            File.Copy(path1, path2);
            Thread.Sleep(100);
            File.Delete(path1);

            //이동
            string path3 = "c:\\Temp\\Test2\\b.dat";
            File.Move(path2, path3);

            //파일 존재 확인
            if (File.Exists(path3))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

            //속성
            Console.WriteLine(File.GetAttributes(path3));
        }
    }
}
