using Microsoft.EntityFrameworkCore;

namespace CRUDMVC01.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
    }
}
