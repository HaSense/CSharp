namespace MethodApp02
{
    class Bank
    {
        //1.멤버 변수
        private int money;
        //2.생성자
        public Bank()
        {
            this.money = 10000;
        }
        //3.멤버 메소드
        //예금하다
        public void Deposit()
        {
            Console.WriteLine($"{money} 금액을 예금하다.");
        }
        public void Deposit(int money)
        {
            Console.WriteLine($"{money} 금액을 예금하다.");
        }
        //인출하다
        public void WithDraw()
        {
            Console.WriteLine($"{money} 금액을 인출하다.");
        }
        //이체하다
        public void Transfer()
        {
            Console.WriteLine($"{money} 금액을 이체하다.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 예금하다 ,인출하다, 이체하다
            //객체
            Bank kb = new Bank();
            kb.Deposit();
            kb.Deposit(1000000);
            kb.WithDraw();
            kb.Transfer();
        }
    }
}
