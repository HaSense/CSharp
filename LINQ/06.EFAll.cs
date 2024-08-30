using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                // 데이터베이스와 테이블이 존재하지 않으면 생성
                context.Database.EnsureCreated();

                // 데이터 추가 (Create)
                var student = new Student
                {
                    Name = "홍길동",
                    HP = "010-3333-3333"
                };
                context.Students.Add(student);
                context.SaveChanges();
                Console.WriteLine("학생이 추가되었습니다.");

                // 데이터 조회 (Read)
                var students = context.Students.ToList();
                Console.WriteLine("모든 학생 목록:");
                foreach (var s in students)
                {
                    Console.WriteLine($"ID: {s.ID}, 이름: {s.Name}, 전화번호: {s.HP}");
                }

                // 데이터 업데이트 (Update)
                var studentToUpdate = context.Students.First();
                studentToUpdate.Name = "김철수";
                context.SaveChanges();
                Console.WriteLine("학생 정보가 업데이트되었습니다.");

                // 업데이트된 데이터 조회
                var updatedStudent = context.Students.First();
                Console.WriteLine($"업데이트된 학생 정보: ID: {updatedStudent.ID}, 이름: {updatedStudent.Name}, 전화번호: {updatedStudent.HP}");

                // 데이터 삭제 (Delete)
                context.Students.Remove(updatedStudent);
                context.SaveChanges();
                Console.WriteLine("학생이 삭제되었습니다.");

                // 삭제 후 데이터 조회
                students = context.Students.ToList();
                Console.WriteLine("남아있는 학생 목록:");
                foreach (var s in students)
                {
                    Console.WriteLine($"ID: {s.ID}, 이름: {s.Name}, 전화번호: {s.HP}");
                }
            }
        }
    }

    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string HP { get; set; }
    }

    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("User Id=scott;Password=tiger;Data Source=localhost:1521/XE");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");
                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.HP).HasColumnName("HP");
            });
        }
    }
}
