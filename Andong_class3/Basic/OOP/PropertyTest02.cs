namespace PropertyTest
{
    class Product
    {
        //private string name;
        //private int price;
        private int stock;

        //Property
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock
        {
            get { return stock; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("재고가 없어요");
                }
                stock = value;
            }
        }
        public Product(string name, int price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("초코파이", 800, 10);
            product.Stock = -5;
        }
    }
}
