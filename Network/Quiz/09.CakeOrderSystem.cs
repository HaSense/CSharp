/* 생산자 소비자 패턴을 응용한 스레드 동기화 문제 */

using System;
using System.Threading;

namespace CakeOrderSystem
{
    public class Cake
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class Chef
    {
        private object _lock = new object();
        public Cake BakeCake(string name, double price)
        {
            lock (_lock)
            {
                Console.WriteLine($"주방장이 {name} 케익을 만들기 시작했습니다.");
                Thread.Sleep(1000); // 케익을 만드는데 1초 소요
                Console.WriteLine($"{name} 케익이 완성되었습니다!");
                return new Cake { Name = name, Price = price };
            }
        }
    }

    public class Customer
    {
        public void OrderCake(Chef chef, string name, double price)
        {
            Console.WriteLine($"손님이 {name} 케익을 주문했습니다.");
            Cake cake = chef.BakeCake(name, price);
            Console.WriteLine($"손님이 {cake.Name} 케익을 받았습니다.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Chef chef = new Chef();
            Customer customer = new Customer();
            Thread[] threads = new Thread[5];

            // 여러 스레드에서 동시에 케익 주문을 시뮬레이션
            for (int i = 0; i < 5; i++)
            {
                string cakeName = $"케익 {i}";
                double cakePrice = 10.0 * (i + 1);

                threads[i] = new Thread(() => customer.OrderCake(chef, cakeName, cakePrice));
                threads[i].IsBackground = true;
                threads[i].Start();
            }

            // 모든 스레드가 완료될 때까지 기다림
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("모든 케익 주문이 완료되었습니다.");
        }
    }
}
