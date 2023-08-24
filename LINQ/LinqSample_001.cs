/* 
   Author : Ha, Sungho
   Date : 2023.08.08
   Context : Linq 문법을 이용하여 데이터베이스를 제어하는 문법입니다.
             DBMS는 오라클 11g Express로 선택하였기에 
             Nuget에서 받는 모듈은 Oracle.ManagedDataAccess.Core은 필수로 받아야 하고
             Linq로 제어하기 위해서는 Oracle.EntityFrameworkCore를 추가로 받아야 합니다.
             현재코드는 Person Table을 만들었습니다.
             CREATE TABLE Person (
               ID      INT PRIMARY KEY,
               NAME    VARCHAR2(30),
               AGE     INT,
               JOB     VARCHAR2(30)
             );

             코드의 context.Database.EnsureCreated()는 테이블을 생성하는 메소드 입니다.
             현재 알수없는 이유로 테이블이 생성되지 않아 원인을 파악하고 있습니다.
*/

using Microsoft.EntityFrameworkCore;

namespace LinqSample_001
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
                // 데이터베이스와 테이블 생성
                //context.Database.EnsureDeleted(); //기존의 테이블이 있을경우 삭제를 단행하는데 DB자체를 지우는 명령어라 타 테이블도 삭제됩니다.
                                                    //조심해서 사용해야할 필요가 있습니다.
                context.Database.EnsureCreated();   //테이블 또는 DB를 만드는 명령어인데 기존에 존재하는 파일이 있다면 아무 작업도 하지 않습니다.
                Console.WriteLine("데이터베이스 테이블이 생성되었습니다.");
            }
        }
    }
}
