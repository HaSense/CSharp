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
                var allPersons = context.Person.ToList();

                context.Person.RemoveRange(allPersons);
                context.SaveChanges();

                Console.WriteLine("모든 데이터 삭제 성공!");
            }
        }
    }
}
