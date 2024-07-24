DECLARE
  -- 사용자 정의 예외 선언
  e_high_salary EXCEPTION;
  -- 급여 한도 선언
  salary_limit CONSTANT NUMBER := 5000;
  -- 직원의 급여를 저장할 변수
  v_salary EMP.SAL%TYPE;
  v_ename EMP.ENAME%TYPE;
BEGIN
  -- 특정 직원의 급여 조회 (예: EMPNO가 7839인 경우)
  SELECT SAL, ENAME INTO v_salary, v_ename
  FROM EMP
  WHERE EMPNO = 7839;

  -- 조건: 급여가 5000 이상일 때 예외 발생
  IF v_salary >= salary_limit THEN
    RAISE e_high_salary; -- 예외 발생
  END IF;

  -- 예외가 발생하지 않았을 경우의 처리
  DBMS_OUTPUT.PUT_LINE(v_ename || '의 급여는 ' || v_salary || '입니다.');
EXCEPTION
  -- 사용자 정의 예외 처리
  WHEN e_high_salary THEN
    DBMS_OUTPUT.PUT_LINE(v_ename || '의 급여는 ' || v_salary || '로, 허용된 한도를 초과했습니다.');
  -- 다른 예외 처리 (옵션)
  WHEN OTHERS THEN
    DBMS_OUTPUT.PUT_LINE('다른 오류가 발생했습니다: ' || SQLERRM);
END;
/
