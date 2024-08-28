namespace BuilderPatternConsole
{
    public class Computer
    {
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string GraphicsCard { get; set; }

        public override string ToString()
        {
            return $"CPU: {CPU}, RAM: {RAM}, Storage: {Storage}, Graphics Card: {GraphicsCard}";
        }
    }

    public interface IComputerBuilder
    {
        void SetCPU();
        void SetRAM();
        void SetStorage();
        void SetGraphicsCard();
        Computer GetComputer();
    }

    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer computer = new Computer();

        public void SetCPU()
        {
            computer.CPU = "Intel Core i9";
        }

        public void SetRAM()
        {
            computer.RAM = "32GB";
        }

        public void SetStorage()
        {
            computer.Storage = "1TB SSD";
        }

        public void SetGraphicsCard()
        {
            computer.GraphicsCard = "NVIDIA RTX 3080";
        }

        public Computer GetComputer()
        {
            return computer;
        }
    }

    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer computer = new Computer();

        public void SetCPU()
        {
            computer.CPU = "Intel Core i5";
        }

        public void SetRAM()
        {
            computer.RAM = "16GB";
        }
        public void SetStorage()
        {
            computer.Storage = "512GB SSD";
        }
        public void SetGraphicsCard()
        {
            computer.GraphicsCard = "Integrated Graphics";
        }
        public Computer GetComputer()
        {
            return computer;
        }
    }
    public class Director
    {
        public Computer BuildComputer(IComputerBuilder builder)
        {
            builder.SetCPU();
            builder.SetRAM();
            builder.SetStorage();
            builder.SetGraphicsCard();
            return builder.GetComputer();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();

            IComputerBuilder gamingBuilder = new GamingComputerBuilder();
            Computer gamingComputer = director.BuildComputer(gamingBuilder);
            Console.WriteLine("게이밍 컴퓨터:");
            Console.WriteLine(gamingComputer);

            IComputerBuilder officeBuilder = new OfficeComputerBuilder();
            Computer officeComputer = director.BuildComputer(officeBuilder);
            Console.WriteLine("오피스 컴퓨터:");
            Console.WriteLine(officeComputer);
        }
    }
}
