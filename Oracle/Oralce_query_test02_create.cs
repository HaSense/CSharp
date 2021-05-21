using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oralce_query_test02_create
{
    class Program
    {
        static void Main(string[] args)
        {
            string strConn = "Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)" +
                "(SERVICE_NAME=xe)));" +
                "User Id=hr;Password=hr;";

            //1.연결 객체 만들기 - Client
            OracleConnection conn = new OracleConnection(strConn);

            //2.데이터베이스 접속을 위한 연결
            conn.Open();

            //3.서버와 함께 신나게 놀기
            //3.1 Query 명령객체 만들기
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn; //연결객체와 연동
            //3.2 명령하기, 테이블 생성하기
            cmd.CommandText = "Create Table PhoneBook " +
                "(ID number(4) PRIMARY KEY,  " +
                "NAME varchar(20), " +
                "HP varchar(20))";
            //3.3 쿼리 실행하기
            cmd.ExecuteNonQuery();
            //4. 리소스 반환 및 종료
            conn.Close();

        }
    }
}
