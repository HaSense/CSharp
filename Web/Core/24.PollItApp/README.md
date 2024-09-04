<h2>설문조사 프로그램 샘플</h2>

1. Nuget 모듈받기<br>
   Install-Package Microsoft.EntityFrameworkCore<br>
   Install-Package Microsoft.EntityFrameworkCore.SqlServer<br>
   Install-Package Microsoft.EntityFrameworkCore.Tools<br>
   Install-Package Microsoft.EntityFrameworkCore.Design<br>

2. 데이터베이스 CodeFirst 방식으로 삽입 또는 미리 만들어 놓기 / 직접 SSMS로 만들었다면 동작 시킬 필요가 없습니다.<br>
   2.1 Nuget-콘솔에서 --> Add-Migration initPoll<br>
   2.2 update-database<br>
   3.3 테이블 만들어 지는 것 확인 하세요.<br>


