using Microsoft.EntityFrameworkCore;
using MVCLogin.Models;

namespace MVCLogin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //세션기능을 추가하고 싶으면 AddSesion()을 등록하세요.
            builder.Services.AddSession(); //단순 세션
            
            //DbContext와 연결해주기 위해 추가됨
            var provider = builder.Services.BuildServiceProvider();
            var config = provider.GetRequiredService<IConfiguration>();
            builder.Services.AddDbContext<LoginDbContext>(item => item.UseSqlServer(config.GetConnectionString("DefaultConnection")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //세션기능을 사용 하려면 꼭 작성 매우중요 !!!
            //build쪽 옵션은 말그대로 옵션 설정이지 정작 동작은 app.UseSession()을 통해서 세션 기능이 동작합니다.
            app.UseSession();


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
