var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages(); //html페이지 사용
var app = builder.Build();

app.UseStaticFiles(); // 정적페이지 사용하기~!!!!

app.MapGet("/", () => "Hello World!");

app.Run();
