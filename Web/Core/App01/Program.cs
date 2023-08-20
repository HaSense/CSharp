using Microsoft.Extensions.WebEncoders;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

//app.MapGet("/", () => "안녕하세요. 처음 배우는 ASP.net Core MVC 입니다.");
//app.MapGet("/hello2", () => "반갑습니다. Hello2 페이지 입니다.");

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/plain; charset=utf-8"; //한글문제 해법
//    await context.Response.WriteAsync("반갑습니다. ASP.NET Core 6");
//});

//Middleware
app.Use(async (context, next) =>
{
    context.Response.ContentType = "text/plain; charset=utf-8"; //한글문제 해법
    await context.Response.WriteAsync("반갑습니다. ASP.NET Core 6");
    await next(context);
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync(" 프로그래밍을 합시다.");
});


app.Run();
