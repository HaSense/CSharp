using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAddressBookApp01
{
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string HP { get; set; }

        public Student(int id, string name, string hp)
        {
            ID = id;
            Name = name;
            HP = hp;
        }
    }
    internal class Program
    {
        private static int N;
        static void UIinit()
        {
            Console.WriteLine("1. 테이블 만들기");
            Console.WriteLine("2. 테이블 삭제");
            Console.WriteLine("3. 데이터 삽입");
            Console.WriteLine("4. 데이터 삭제");
            Console.WriteLine("5. 데이터 수정");
            Console.WriteLine("6. 데이터 검색");

            Console.WriteLine("7. 프로그램 종료");

            Console.Write("메뉴 : ");
            N = int.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            while (true)
            {
                UIinit();
                switch (N)
                {
                    case 1:
                        //테이블을 만들어 주세요.
                        break;
                    case 2:
                        //테이블을 삭제해 주세요.
                        break;
                    case 3:
                        //데이터 삽입 기능을 만들어 주세요.
                        break;
                    case 4:
                        //데이터 삭제 기능을 만들어 주세요.
                        break;
                    case 5:
                        //데이터 수정 기능을 만들어 주세요.
                        break;
                    case 6:
                        //데이터 검색 기능을 만들어 주세요.
                        break;
                    case 7:
                        Console.WriteLine("\n프로그램을 종료합니다.\n");
                        Console.WriteLine("안녕히 계세요. 수고하셨습니다.\n");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\n잘못된 메뉴를 입력하셨습니다. \n\n다시 입력 해 주세요.\n");
                        break;
                }
            }
        }
    }
}
