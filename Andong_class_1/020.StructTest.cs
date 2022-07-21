using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructTest
{
    struct School
    {
        public string schName;
        public string stName;
        public int stGrade;
    }
    struct Coordinates
    {
        int x;
        int y;
        //구조체 생성자는 디폴트생성자는 구현할 수 없고
        //멤버를 초기화 하기위한 생성자는 가능
        Coordinates( int x, int y) //멤버 초기화
        {
            this.x = x;
            this.y = y;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            School sc; // class와 비교 new 하지 않음!!!!
            sc.schName = "ABC 고등학교";
            sc.stName = "홍길동";
            sc.stGrade = 3;

            Console.WriteLine(sc.schName);
        }
    }
}
