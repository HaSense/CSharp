var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/Home", async (context) =>
    {
        context.Response.ContentType = "text/plain; charset=utf-8"; //한글문제 해법
        await context.Response.WriteAsync("홈페이지 입니다. - Get");
    });
    endpoints.MapPost("/Home", async (context) =>
    {
        await context.Response.WriteAsync("홈페이지 입니다. - Post");
    });
    endpoints.MapDelete("/Home", async (context) =>
    {
        await context.Response.WriteAsync("홈페이지 입니다. - Delete");
    });
    endpoints.MapPut("/Home", async (context) =>
    {
        await context.Response.WriteAsync("홈페이지 입니다. - Put");
    });

});

//app.MapGet("/Home", () => "Hello World! - Get");
//app.MapPost("/Home", () => "Hello World! - POST");
//app.MapPut("/Home", () => "Hello World! - PUT");
//app.MapDelete("/Home", () => "Hello World! - DELETE");



app.Run(async (HttpContext context) =>
{
    context.Response.ContentType = "text/plain; charset=utf-8";
    await context.Response.WriteAsync("페이지를 찾을 수 없습니다.");
});
app.Run();
