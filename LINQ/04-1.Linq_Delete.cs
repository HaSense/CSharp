using Microsoft.EntityFrameworkCore;

namespace AAA
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
                // 홍길동을 찾기
                var personToDelete = context.Person.FirstOrDefault(p => p.NAME == "홍길동");

                // 해당 레코드가 존재하면 삭제하기
                if (personToDelete != null)
                {
                    context.Person.Remove(personToDelete);

                    // 변경 사항 저장
                    context.SaveChanges();
                    Console.WriteLine("홍길동 데이터 삭제 성공!");
                }
                else
                {
                    Console.WriteLine("홍길동 데이터를 찾을 수 없습니다.");
                }
            }
        }
    }
}
