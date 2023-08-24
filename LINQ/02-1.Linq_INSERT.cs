using Microsoft.EntityFrameworkCore;

namespace Linq_Create2
{
    public class Person
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public int AGE { get; set; }
        public string JOB { get; set; }
    }
    public class PersonContext : DbContext
    {
        public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("User Id=c##scott;Password=tiger;Data Source=127.0.0.1/XE;");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PersonContext())
            {
                context.Database.EnsureCreated(); //테이블이 있다면 아무 동작도 하지 않습니다.
                // 데이터 삽입
                var persons = new List<Person>
                {
                    new Person { ID = 1, NAME = "홍길동", AGE = 20, JOB = "의적" },
                    new Person { ID = 2, NAME = "이순신", AGE = 45, JOB = "장군" },
                    new Person { ID = 3, NAME = "유관순", AGE = 17, JOB = "독립투사" },
                    new Person { ID = 4, NAME = "이재용", AGE = 55, JOB = "그룹회장" }
                };

                context.Person.AddRange(persons);
                context.SaveChanges();
                Console.WriteLine("데이터 삽입 성공!");
            }
        }
    }
}
