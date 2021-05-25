using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //C#에서 텍스트 파일에 글을 적는 방법~!!!
            using (StreamWriter sw =
                new StreamWriter(new FileStream("abc.txt", FileMode.Create)))
            {
                sw.WriteLine(int.MaxValue);
                sw.WriteLine("Good morning");
                sw.WriteLine(uint.MaxValue);
                sw.WriteLine("안녕하세요~!");
            }
            /////////////////////////////////////////////
            //c#에서 텍스트 파일을 읽어 오려면~~!!!
            File.Copy("abc.txt", "xyz.txt");

            using(StreamReader sr =
                new StreamReader(new FileStream("xyz.txt", FileMode.Open)))
            {
                while(sr.EndOfStream == false)
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }

        }
    }
}
