using Microsoft.EntityFrameworkCore;

namespace PollItApp.Models
{
    public class PollDbContext : DbContext
    {
        public PollDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Poll> Polls { get; set;}

    }
}
