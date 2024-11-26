using Microsoft.EntityFrameworkCore;

namespace MVCLogin.Models
{
    public class LoginDbContext : DbContext
    {
        //options인자가 있는 생성자 만듦
        public LoginDbContext(DbContextOptions options) : base(options)
        {
        }

        //테이블에 해당하는 클래스 만듦
        public DbSet<LoginUser> LoginUsers { get; set; }
    }
}
