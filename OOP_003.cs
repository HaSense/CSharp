using System;

namespace OOP_003
{
    class Mammal : Object
    {

    }
    class Dog : Mammal
    {

    }
    class Chiwawa : Dog
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Mammal mammal = new Mammal();
            Dog dog = new Dog();
            Chiwawa chiwawa = new Chiwawa();

            Dog dog2 = new Chiwawa();
            Mammal mammal2 = new Dog();

            Object obj1 = new Chiwawa();
            Object obj2 = new Dog();
            Object obj3 = new Mammal();

            chiwawa = (Chiwawa)obj1;
            dog = (Dog)obj2;
            
        }
    }
}
