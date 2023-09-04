오라클 18c Express에서 테스트 하였습니다.

필요한 모듈 3가지
1. Oracle.ManagedDataAccess.Core [3.21.110 사용]
2. Oracle.EntityFrameworkCore [7.21.11]
3. Microsoft.EntityFrameworkCore.Tools [7.0.10] --> 데이터마이그레이션으로 테이블을 만들려면

DB연결 스크립트
 - appsettings.json
 - Program.cs

DB 마이그레션 시 명령어
 1. add-migration initialcreate
 2. update-database

테이블을 미리 만들어 놓았으면 당연히 마이그레션을 할 필요는 없습니다.
마이그레션은 자동으로 DB에 테이블을 생성하려는 행동이기 때문입니다.

protected override void OnModelCreating(ModelBuilder modelBuilder)
{

    modelBuilder.Entity<Student>()
        .Property(s => s.Id)
        .ValueGeneratedOnAdd();
    modelBuilder.Entity<Student>()
        .Property(s => s.Id)
        .HasDefaultValueSql("STUDENT_ID_SEQ.NEXTVAL");
}

DBContext 코드에 .ValueGeneratedOnAdd()를 넣으면 자동으로 시퀀스가 만들어 진다고 했지만 자동으로 생성은 되지 않았네요.
그래도 코드에 그냥 남겨 두었습니다.

.HasDefaultValueSQL("STUDENT_ID_SEQ.NETVAL") 
시퀀스를 통한 AutoIncrement 기능을 하려고 할때 시퀀스로 부터 다음 시퀀스ID를 가져오는 명령어 입니다.

시퀀스가 자동으로 만들어 지지 않아 수동으로 STUDENT_ID_SEQ란 이름의 시퀀스를 제가 직접 만들었네요.
시퀀스의 크기는 여러분이 지난 수업때 처럼 999999999 처럼 크게 잡으시면 되고 1씩 증가하게 만드세요.

테스트 결과 저는 정상 동작합니다.

그리고 MSSQL로 만든 BasicCRUD는 HomeController에서만 작업한것 같아.
CRUDController를 따로 만들어서 CRUD 기능을 구현해 보았습니다.



   
