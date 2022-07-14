using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WowWorld
{
    class Hero
    {
        private string name;
        private int level;
        private string job;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Level { get; set; }
        public string Job { get; set; }
    }
    class Knight : Hero
    {
        public Knight(string name)
        {
            Name = name;
            Level = 1;
        }
    }
    class DarkKnight : Knight
    {
        public DarkKnight(string name) : base(name)
        {

        }
    }
    class Wizzard : Hero
    {

    }

    class Story
    {
        public void introShow()
        {
            Console.WriteLine("때는 BC1000년 세상에 어둠이 깔리고...\n");
            Thread.Sleep(1000);
            Console.WriteLine("세상은 영웅을 필요로 하게 되는데 ...\n");
            Thread.Sleep(1000);
            Console.WriteLine("영웅이 탄생되었다.\n");
            Thread.Sleep(1000);
            Console.WriteLine("영웅의 직업을 선택하세요. [1] 기사 [2] 마법사");
            Thread.Sleep(1000);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Story story = new Story();
            story.introShow();

            Hero hero = new Knight("홍길동");
            Console.WriteLine(hero.Level);

        }
    }
}
