using Microsoft.EntityFrameworkCore;

namespace EF6_InsertData
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Major { get; set; }
    }
    public class StudentDbContext : DbContext
    {
        //테이블
        public DbSet<Student> Student { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("User Id=c##scott;Password=tiger;Data Source=127.0.0.1/XE;");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new StudentDbContext())
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                // 데이터 삽입
                Console.Write("ID를 입력해 주세요: ");
                int id;
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("잘못된 ID 입력!");
                    return;
                }

                Console.Write("이름을 입력해 주세요: ");
                string name = Console.ReadLine();

                Console.Write("전공을 입력해 주세요: ");
                string major = Console.ReadLine();

                var student = new Student { Id = id, Name = name, Major = major };

                context.Student.AddRange(student);
                context.SaveChanges();
                Console.WriteLine("데이터베이스 테이블이 생성되었습니다.");
            }
        }
    }
}
