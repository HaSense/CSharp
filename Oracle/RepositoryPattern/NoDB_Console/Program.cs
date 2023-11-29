using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternConsole
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        // 기타 필드...
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<Product> productRepository = new Repository<Product>();

            // 제품 추가
            var product1 = new Product { Id = 1, Name = "그랜저" };
            productRepository.Add(product1);
            var product2 = new Product { Id = 2, Name = "아이오닉5" };
            productRepository.Add(product2);

            // 특정 제품 검색 및 출력
            var retrievedProduct = productRepository.Get(1);
            Console.WriteLine("검색된 제품: " + retrievedProduct.Name);

            // 모든 제품 조회 및 출력
            Console.WriteLine("\n모든 제품 목록:");
            foreach (var product in productRepository.GetAll())
            {
                Console.WriteLine("ID: " + product.Id + ", 이름: " + product.Name);
            }

            // 기타 CRUD 작업...
        }
    }
}
