using Microsoft.EntityFrameworkCore;

namespace BasicCRUD.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
    }
}
