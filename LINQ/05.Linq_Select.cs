using Microsoft.EntityFrameworkCore;

namespace Linq_Select
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
                var persons = context.Person.ToList();
            
                // 헤더 출력
                Console.WriteLine($"{nameof(Person.ID),-5} {nameof(Person.NAME),-15} {nameof(Person.AGE),-5} {nameof(Person.JOB),-15}");
                Console.WriteLine(new string('-', 40));
                /* nameof 연산자는 C# 6.0에서 도입된 연산자로, 변수, 타입, 또는 멤버의 이름을 문자열로 반환
                   주로 예외 메시지나 로깅, 속성명 변경 알림 등에서 사용 */
                
                // 데이터 출력
                foreach (var p in persons)
                {
                    Console.WriteLine($"{p.ID,-5} {p.NAME,-15} {p.AGE,-5} {p.JOB,-15}");
                }
            }
        }
    }
}
