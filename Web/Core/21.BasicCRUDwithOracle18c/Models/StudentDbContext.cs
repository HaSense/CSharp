using Microsoft.EntityFrameworkCore;

namespace BasicCRUDwithOracle18cEx.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Student>()
                .Property(s => s.Id)
                .HasDefaultValueSql("STUDENT_ID_SEQ.NEXTVAL");
        }
        public DbSet<Student> Student { get; set; }
    }
}
