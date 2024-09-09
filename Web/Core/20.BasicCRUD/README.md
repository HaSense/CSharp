[Entity Framework 패키지 설치]

Install-Package Microsoft.EntityFrameworkCore 
Install-Package Microsoft.EntityFrameworkCore.SqlServer 
Install-Package Microsoft.EntityFrameworkCore.Tools 
Install-Package Microsoft.EntityFrameworkCore.Design 


[CodeFirst 방식 DB테이블 만들기]

- Add-Migration InitCRUD
- Update-Database
