using Microsoft.EntityFrameworkCore;
using System;

namespace Linq_update1
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
                // 유관순을 찾기
                var personToEdit = context.Person.FirstOrDefault(p => p.NAME == "유관순");

                // 해당 레코드가 존재하면 수정하기
                if (personToEdit != null)
                {
                    personToEdit.NAME = "강감찬";
                    personToEdit.AGE = 40; // 강감찬의 나이나 직업 등을 알지 못하므로 예시로 적어둡니다.
                    personToEdit.JOB = "장군";

                    // 변경 사항 저장
                    context.SaveChanges();
                    Console.WriteLine("데이터 수정 성공!");
                }
                else
                {
                    Console.WriteLine("유관순 데이터를 찾을 수 없습니다.");
                }
            }
        }
    }
}
