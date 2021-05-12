using System;
using System.Collections;
using System.Threading;

namespace ConsoleGame01
{
    class Knight
    {
        public string Name;
        public int Level;

        public Knight()
        {

        }
        public Knight(string _Name, int _Level)
        {
            Name = _Name;
            Level = _Level;
        }
    }
    class DarkKnight : Knight
    {
        public string Wing;
    }
    class Story
    {
        public void IntroInit()
        {
            //Thread.Sleep(1000);
            //Console.WriteLine("때는 BC300년경 새로운 판타지의 세계가 열렸다.\n");
            //Thread.Sleep(1000);
            //Console.WriteLine("우리의 주인공 T는 기사로 지금껏 살아왔다.\n");
            //Thread.Sleep(1000);
            //Console.WriteLine("주인공 T의 미래는 어떻게 될 것인가???\n");
            //Thread.Sleep(1000);

            ArrayList arr = new ArrayList();
            arr.Add("때는 BC300년경 새로운 판타지의 세계가 열렸다.");
            arr.Add("우리의 주인공 T는 기사로 지금껏 살아왔다.");
            arr.Add("주인공 T의 미래는 어떻게 될 것인가???");

            foreach(string s in arr)
            {
                Thread.Sleep(1500);
                Console.WriteLine(s + "\n");
            }
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Story story = new Story();
            story.IntroInit();

            Knight tomy = new Knight("토미", 1);
            Console.WriteLine($"{tomy.Name}이 탄생하였습니다.");
            Console.WriteLine($"현재 레벨은 {tomy.Level} 입니다.");
        }
    }
}
