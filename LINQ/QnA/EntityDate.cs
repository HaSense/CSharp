using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkGameCD
{
    public class GameCD
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        //public DateTime Date { get; set; } = DateTime.Now;
    }
    public class GameCDContext : DbContext
    {
        //테이블
        public DbSet<GameCD> GameCD { get; set; }

        //접속 문자열
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("User Id=c##scott;Password=tiger;Data Source=127.0.0.1/XE;");
        }
        //테이블 생성 및 제약
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameCD>()   //Primary key 지정
                .HasKey(g => g.Id);

            modelBuilder.Entity<GameCD>()   //Varchar2(30) 30크기를 정할 때
            .Property(g => g.Title)
                .HasMaxLength(30);

            modelBuilder.Entity<GameCD>()
            .Property(p => p.Date)
                .HasColumnType("date"); // 데이터베이스에 따라 적절한 타입을 선택합니다.
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new GameCDContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                // 데이터 삽입
                var games = new List<GameCD>
                {
                    new GameCD { Id = 1, Title = "디아블로4", Date = new DateTime(2023, 8, 24)},
                    new GameCD { Id = 2, Title = "롤드컵", Date = new DateTime(2023, 8, 24) },
                    new GameCD { Id = 3, Title = "FIFA2023", Date = new DateTime(2023, 8, 24) },
                    new GameCD { Id= 4, Title = "어쎄신크리드", Date = new DateTime(2023, 8, 24)}
                };

                context.GameCD.AddRange(games);
                context.SaveChanges();
                Console.WriteLine("데이터베이스 테이블이 생성되었습니다.");
            }
        }
    }
}
