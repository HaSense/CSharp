var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
//app.MapGet("/", () => "Hello World!");
app.MapControllerRoute(
    name:"dafault",
    pattern:"{controller=Home}/{action=Index}/{id?}");

app.Run();
