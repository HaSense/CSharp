[Entity Framework 패키지 설치]

Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design

[CodeFirst 방식 DB테이블 만들기]

Add-Migration InitCRUD
Update-Database

[초기에 신경써야하는 파일]

1. appsetting.json 
   //MSSQL연결을 위한 스크립트 삽입 SmartFactorDb 데이터베이스에 MS_SQL_Express 로컬로 접속
   "ConnectionStrings": {
      "DefaultConnection": "Server=(local)\\SQLEXPRESS;Database=SmartFactoryDb;Trusted_Connection=True;Encrypt=False"
   },

2. Program.cs
   //세션기능을 추가하고 싶으면 AddSesion()을 등록하세요.
   builder.Services.AddSession(); //단순 세션

   //DbContext와 연결해주기 위해 추가됨
   var provider = builder.Services.BuildServiceProvider();
   var config = provider.GetRequiredService<IConfiguration>();
   builder.Services.AddDbContext<LoginDbContext>(item => item.UseSqlServer(config.GetConnectionString("DefaultConnection")));

  //세션기능을 사용 하려면 꼭 작성 매우중요 !!!
  //build쪽 옵션은 말그대로 옵션 설정이지 정작 동작은 app.UseSession()을 통해서 세션 기능이 동작합니다.
  app.UseSession();

3. HomeController.cs --> Login(get, post), Logout, Sign(get, post)
4. LoginUser.cs, LoginDbContext.cs
5. index.cshtml, Login.cshtml, SignUp.cshtml
6. Views/Shared/_Layout.cshtml 수정하세요.
