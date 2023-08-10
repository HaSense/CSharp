/*
  현재 코드는 함수만 참고하세요.
  결과적으로 ExecuteNonQuery()로 한번에 실행하면 됩니다.
/*
using (OracleConnection conn = new OracleConnection(connectionString))
{
    conn.Open();
    OracleCommand cmd = conn.CreateCommand();
    
    // 트랜잭션 시작
    OracleTransaction transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
    cmd.Transaction = transaction;

    try
    {
        // 4개의 쿼리를 연결
        string query1 = "UPDATE table1 SET column1 = value1 WHERE condition1;";
        string query2 = "UPDATE table2 SET column2 = value2 WHERE condition2;";
        string query3 = "UPDATE table3 SET column3 = value3 WHERE condition3;";
        string query4 = "UPDATE table4 SET column4 = value4 WHERE condition4;";

        string combinedQuery = query1 + query2 + query3 + query4;

        cmd.CommandText = combinedQuery;
        cmd.ExecuteNonQuery();

        // 모든 쿼리가 성공하면 트랜잭션 커밋
        transaction.Commit();
    }
    catch (Exception ex)
    {
        // 에러가 발생하면 롤백
        transaction.Rollback();
        Console.WriteLine(ex.ToString());
    }
}
