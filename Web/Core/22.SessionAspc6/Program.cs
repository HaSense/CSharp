var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//세션기능을 추가하고 싶으면 AddSesion()을 등록하세요.
//builder.Services.AddSession(); //단순등록
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(10); //세션 유지시간은 보통 20분 정도인데 10분으로 줄여 놓았습니다. 즉, 세션 시간을 정하는 코드
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//세션기능을 사용 하려면 꼭 작성해야 합니다. build쪽 옵션은 말그대로 옵션 설정이지 정작 동작은 app.UseSession()을 통해서 세션 기능이 동작합니다.
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
