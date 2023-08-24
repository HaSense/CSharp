/*
    현재 2023.08.08
    오라클11g express에서 테이블이 만들어 있을 경우 아래 삽입코드는 정상동작합니다.
*/
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace LinqSample_003
{
    [Table("PERSON", Schema = "c##scott")]
    public class Person
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public int AGE { get; set; }
        public string JOB { get; set; }
    }
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("User Id=c##scott;Password=tiger;Data Source=127.0.0.1/XE;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()   //Primary key 지정
                .HasKey(p => p.ID);

            modelBuilder.Entity<Person>()   //Varchar2(30) 30크기를 정할 때
                .Property(p => p.NAME)
                .HasMaxLength(30);

            modelBuilder.Entity<Person>()
                .Property(p => p.JOB)
                .HasMaxLength(30);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new PersonContext())
            {
                // 데이터베이스와 테이블 생성 (필요한 경우)
                //context.Database.EnsureCreated(); 

                // 데이터 삽입
                var persons = new List<Person>
                {
                    new Person { ID = 1, NAME = "홍길동", AGE = 20, JOB = "의적" },
                    new Person { ID = 2, NAME = "이순신", AGE = 45, JOB = "장군" },
                    new Person { ID = 3, NAME = "유관순", AGE = 17, JOB = "독립투사" },
                    new Person { ID = 4, NAME = "이재용", AGE = 55, JOB = "그룹회장" }
                };

                context.Persons.AddRange(persons);
                context.SaveChanges();
                Console.WriteLine("데이터 삽입 성공!");
            }
        }
    }
}
