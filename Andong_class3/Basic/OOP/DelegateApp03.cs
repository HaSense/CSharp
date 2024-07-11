namespace DelegateApp03
{
    class Calculator
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }
        public int Minus(int a, int b)
        {
            return a - b;
        }

        public double Divide(int a, int b)
        {
            return (double)a / b;
        }

    }
    internal class Program
    {
        //public delegate int Compute(int a, int b); //선언!!!
                
        static void Main(string[] args)
        {
            int a = 100, b = 200;
            Calculator calculator = new Calculator();
            //Compute compute = calculator.Plus;
            Func<int, int, int> intCompute = calculator.Plus;
            //Console.WriteLine("덧셈 : {0}", compute(a, b));
            Console.WriteLine("덧셈 : {0}", intCompute(a, b));

            //compute = calculator.Minus;
            intCompute = calculator.Minus;
            //Console.WriteLine("뺄셈 : {0}", compute(a, b));
            Console.WriteLine("뺄셈 : {0}", intCompute(a, b));

            //compute = calculator.Divide;
            Func<int, int, double> doubleCompute = calculator.Divide;
            //Console.WriteLine("나눗셈 : {0}", compute(a, b));
            Console.WriteLine("나눗셈 : {0}", doubleCompute(a, b));
        }
    }
}
