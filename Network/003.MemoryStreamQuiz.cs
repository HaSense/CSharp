using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Temp\\abc.txt";
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            string txt = sr.ReadToEnd();
            sr.Close();
            Console.WriteLine(txt);

            //MemoryStream 
            MemoryStream ms = new MemoryStream();
            byte[] strBytes = Encoding.UTF8.GetBytes(txt);
            ms.Write(strBytes, 0, strBytes.Length);

            ms.Position = 0; //함정
            StreamReader sr2 = new StreamReader(ms, Encoding.UTF8, true);
            string txt2 = sr2.ReadToEnd();

            Console.WriteLine(txt2);

        }
    }
}
