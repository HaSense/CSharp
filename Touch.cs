using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touch
{
    class Program
    {
        static void OnWrongPathType(string type)
        {
            Console.WriteLine($"{type}이 잘못된 타입입니다.");
            return;
        }

        static void Main(string[] args)
        {
            //File.Copy("abc.txt", "xyz.txt");
            if (args.Length == 0)
            {
                Console.WriteLine("사용법 : Touch.exe <PATH> [Type:File/Directory]");
                return;
            }
            string path = args[0]; //첫번째 매개변수에 파일의 경로 e.g C:\Windows
            string type = "File";
            if (args.Length > 1)
                type = args[1];

            //파일이 존재하는지 여부
            if (File.Exists(path) || Directory.Exists(path))
            {
                if (type == "File")
                    File.SetLastWriteTime(path, DateTime.Now);
                else if (type == "Directory")
                    Directory.SetLastWriteTime(path, DateTime.Now);
                else
                {
                    //예외처리
                    OnWrongPathType(path);
                }
            }
            else
            {
                if (type == "File")
                    File.Create(path).Close();
                else if (type == "Directory")
                    Directory.CreateDirectory(path);
                else
                {
                    OnWrongPathType(path);
                }
                Console.WriteLine($"경로가 생성되었습니다. {path} {type}");
            }

        }
    }
}
