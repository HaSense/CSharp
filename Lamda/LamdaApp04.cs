namespace LamdaExam04
{
    internal class Program
    {
        /* 직관적인 Action설명 
           Action은 반환값(return)이 없다.
           Func는 반환값(return)이 있다.
        */
      
        static void Main(string[] args)
        {
            Action act1 = () => Console.WriteLine("Action()");
            act1();

            int result = 0;
            Action<int> act2 = (x) => result = x * x;
            act2(3);
            Console.WriteLine(result);

            Action<double, double> act3 = (x, y) =>
            {
                double pi = x / y;
                Console.WriteLine(pi);
            };
            act3(22.0, 7.0);
        }
    }
}
