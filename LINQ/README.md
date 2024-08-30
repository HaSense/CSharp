
-- 1. 계정 생성<br>
CREATE USER smart IDENTIFIED BY factory;

-- 2. 기본 권한 부여<br>
GRANT CONNECT, RESOURCE TO smart;

-- 무제한 개인 테이블 공간 부여하려면!! <br>
grant unlimited tablespace to smart;

-- 임시공간 부여 <br>
alter user smart temporary tablespace temp;
