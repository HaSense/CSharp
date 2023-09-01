콘솔 어플입니다.

설치 모듈은
1. EntityFrameworkCore.SqlServer
2. EntityFrameworkCore.Tools
3. NAudio --> mp3, wav 파일 실행 모듈

테이블을 만들어 두면 좋습니다.
CREATE TABLE [dbo].[MP3Files](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[Data] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_MP3Files] PRIMARY KEY

바이너리로 저장할때 sqlserver는 타입이 varbinary네요.

마이그레이션으로 생성하려면 EntityFrameworkCore.Tools가 다운로드 되어 있어야하고
Nuget-Package 관리자를 실행하고
1. add-migration initialcreate
2. update-database
로 실행하면 DB테이블이 만들어집니다.

음악파일을 입력하는 경로는 기본 경로로 하였습니다.
C:\Users\[사용자경로]\source\repos\Mp3SqlServerApp\bin\Debug\net6.0

.NET Core 6.0 콘솔 프로젝트로 했더니 net6.0 폴더가 생성되던데 net6.0 폴더 안쪽이 Root Home 입니다. 



