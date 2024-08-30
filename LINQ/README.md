
-- 1. 계정 생성
CREATE USER smart IDENTIFIED BY factory;

-- 2. 기본 권한 부여
GRANT CONNECT, RESOURCE TO smart;

-- 무제한 개인 테이블 공간 부여하려면!!
grant unlimited tablespace to smart;

-- 임시공간 부여
alter user smart temporary tablespace temp;



-- 기본 테이블 공간으로 할당하려면 아래처럼
alter user smart default tablespace users;
