using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace SQLParameterTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //C# SqlConnection, SqlParameter, SqlCommand는 MS_SQL에서만 동작

            string strConn = @"Data Source=
                        (DESCRIPTION =
                            (ADDRESS_LIST =
                                (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
                            )
                            (CONNECT_DATA =
                            (SERVICE_NAME = xe)
                            )
                        );User Id=hr;Password=hr";

            //1.연결 객체 만들기 - Client
            OracleConnection conn = new OracleConnection(strConn);
            //2.데이터베이스 접속을 위한 연결
            conn.Open();

            //3.DBMS서버로 보낼 쿼리 작성하기
            // ~~~~~~~~
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO STUDENT_TEMP (ID, NAME, PNUMBER) " +
                                    "VALUES (:ID, :NAME, :PNUMBER)";

            cmd.Parameters.Add(new OracleParameter("ID", 3));
            cmd.Parameters.Add(new OracleParameter("NAME", "홍길동"));
            cmd.Parameters.Add(new OracleParameter("PNUMBER", "010-1111-1111"));

            cmd.ExecuteNonQuery();

            //같은결과 다른표현
            //string sql = "INSERT INTO STUDENT_TEMP VALUES (:ID, :NAME, :PNUMBER)";
            //OracleCommand cmd = new OracleCommand(sql, conn); //한번에 처리 가능

            //OracleParameter[] parameters = new OracleParameter[] {
            // new OracleParameter("ID",5),
            // new OracleParameter("NAME","홍길동"),
            // new OracleParameter("PNUMBER","010-1111-1111")
            //};
            //cmd.Parameters.AddRange(parameters);
            //cmd.ExecuteNonQuery();


            //4. 리소스 반환 및 종료
            conn.Close();
        }
    }
}

/* #테스트 테이블 구조
#Student Temp 테스트 테이블 만들기
CREATE TABLE STUDENT_TEMP (
    ID  NUMBER(3) PRIMARY KEY,
    NAME VARCHAR2(20),
    PNUMBER VARCHAR2(30)
);
*/
