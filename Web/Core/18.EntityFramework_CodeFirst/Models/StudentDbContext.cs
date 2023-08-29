using Microsoft.EntityFrameworkCore;

namespace CodeFirst01.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }    
    }
}
