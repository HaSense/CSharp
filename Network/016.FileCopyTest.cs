using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopyTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //File 클래스를 이용한 Copy
            string path1 = "c:\\temp\\KOR_1.exe";
            byte[] buffer = File.ReadAllBytes(path1);
            
            string path2 = "c:\\temp\\KOR_2.exe";
            File.WriteAllBytes(path2, buffer);

            //File 클래스를 이용한 Copy 2번째 버전
            File.Copy(path1, path2, true);

        }
    }
}
