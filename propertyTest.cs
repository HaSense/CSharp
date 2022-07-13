namespace OOPTest02
{
    class Cat
    {
        private string name; //속성, 직접접근(X) 간접접근

        //Getter, Setter
        //public void setName(string name)
        //{
        //    this.name = name;
        //}
        //public string getName()
        //{
        //    return this.name;
        //}

        public string Name
        {
            get;
            set;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat tom = new Cat();
            //tom.setName("톰");
            //Console.WriteLine(tom.getName());
            tom.Name = "톰";
            Console.WriteLine(tom.Name);
        }
    }
}
