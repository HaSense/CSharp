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
        IComputerBuilder SetCPU(string cpu);
        IComputerBuilder SetRAM(string ram);
        IComputerBuilder SetStorage(string storage);
        IComputerBuilder SetGraphicsCard(string graphicsCard);
        Computer Build();
    }

    public class ComputerBuilder : IComputerBuilder
    {
        private Computer computer = new Computer();

        public IComputerBuilder SetCPU(string cpu)
        {
            computer.CPU = cpu;
            return this;
        }

        public IComputerBuilder SetRAM(string ram)
        {
            computer.RAM = ram;
            return this;
        }

        public IComputerBuilder SetStorage(string storage)
        {
            computer.Storage = storage;
            return this;
        }

        public IComputerBuilder SetGraphicsCard(string graphicsCard)
        {
            computer.GraphicsCard = graphicsCard;
            return this;
        }

        public Computer Build()
        {
            return computer;
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            IComputerBuilder gamingBuilder = new ComputerBuilder();
            Computer gamingComputer = gamingBuilder
                                        .SetCPU("Intel Core i9")
                                        .SetRAM("32GB")
                                        .SetStorage("1TB SSD")
                                        .SetGraphicsCard("NVIDIA RTX 3080")
                                        .Build();
            Console.WriteLine("게이밍 컴퓨터:");
            Console.WriteLine(gamingComputer);

            IComputerBuilder officeBuilder = new ComputerBuilder();
            Computer officeComputer = officeBuilder
                                        .SetCPU("Intel Core i5")
                                        .SetRAM("16GB")
                                        .SetStorage("512GB SSD")
                                        .SetGraphicsCard("Integrated Graphics")
                                        .Build();
            Console.WriteLine("오피스 컴퓨터:");
            Console.WriteLine(officeComputer);
        }
    }
}
