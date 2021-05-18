using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Class_Collection
{
    class Cat
    {
        private string name;
        private string color;

        public string Name { get; set; }
        public string Color { get; set; }
    }
    class Persian : Cat 
    { 
    }
    class Dog
    {
        private string name;
        private string color;

        public string Name { get; set; }
        public string Color { get; set; }
    }
    class BullDog : Dog
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Persian kitty = new Persian();
            Persian bbomi = new Persian();
            kitty.Name = "키티";
            kitty.Color = "하얀색";
            bbomi.Name = "뽀미";
            bbomi.Color = "회색";

            BullDog tomy = new BullDog();
            BullDog kaltok = new BullDog();
            tomy.Name = "토미";
            tomy.Color = "검은색";
            kaltok.Name = "칼톡";
            kaltok.Color = "회백색";


            ArrayList animal = new ArrayList();
            animal.Add(kitty);
            animal.Add(bbomi);
            animal.Add(tomy);
            animal.Add(kaltok);

            for (int i = 0; i < animal.Count-2; i++)
                Console.WriteLine(((Cat)animal[i]).Name);
            for (int i = 2; i < animal.Count; i++)
                Console.WriteLine(((Dog)animal[i]).Name);


            List<Cat> catList = new List<Cat>();
            catList.Add(kitty);
            catList.Add(bbomi);
            foreach (Cat c in catList)
            {
                Console.WriteLine($"{c.Name} : {c.Color}");
            }
                
           
            Stack<Dog> dogStack = new Stack<Dog>();
            dogStack.Push(tomy);
            dogStack.Push(kaltok);

            for (int i = 0; i <= dogStack.Count; i++)
                Console.WriteLine((dogStack.Pop()).Name);
        }
    }
}


