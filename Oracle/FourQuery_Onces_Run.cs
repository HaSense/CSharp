/* 
  한번에 다수의 쿼리를 사용하려면 
  P/L SQL 문법을 사용하여 처리할 수 있습니다.
*/

using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ThreeQueryOnce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SELECT 데이터 조회
            string strConn = "Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)" +
                "(SERVICE_NAME=xe)));" +
                "User Id=hr;Password=hr;";

            OracleConnection conn = new OracleConnection(strConn);


            conn.Open();
            OracleCommand cmd = conn.CreateCommand();

            // 트랜잭션 시작
            OracleTransaction transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            cmd.Transaction = transaction;

            try
            {
                string combinedQuery = @"
                     BEGIN
                            UPDATE DEPT2 SET LOC='서울' WHERE LOC='BOSTON';
                            UPDATE DEPT2 SET LOC='울산' WHERE LOC='CHICAGO';
                            UPDATE DEPT2 SET LOC='부산' WHERE LOC='NEW YORK';
                            UPDATE DEPT2 SET LOC='안동' WHERE LOC='DALLAS';
                     END;";

                cmd.CommandText = combinedQuery;
                cmd.ExecuteNonQuery();

                //모든 쿼리가 성공하면 트랜잭션 커밋
                transaction.Commit();
                Console.WriteLine("동작성공");
            }
            catch (Exception ex)
            {
                // 에러가 발생하면 롤백
                transaction.Rollback();
                Console.WriteLine(ex.ToString());
                Console.WriteLine("동작실패");
            }

        }
    }
}
