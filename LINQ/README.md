
-- 1. 계정 생성<br>
CREATE USER smart IDENTIFIED BY factory;

-- 2. 기본 권한 부여<br>
GRANT CONNECT, RESOURCE TO smart;

-- 무제한 개인 테이블 공간 부여하려면!! <br>
grant unlimited tablespace to smart;

-- 임시공간 부여 <br>
alter user smart temporary tablespace temp;


-- 오라클의 경우 받아야 되는 모듈<br>
1) Oracle.EntityFrameworkCore <br>
2) Oracle.ManagedDataAccess.Core <br>
-- Codefirst 등 작업시<br>
3) Microsoft.EntityFramework.Tools <br>
-- TagHelper의 Model 관련 Form 디자인할때 <br>   
4) Microsoft.VisualStudio.Web.CodeGeneration.Design<br>

