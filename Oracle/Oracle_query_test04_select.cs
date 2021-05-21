using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_query_test04_select
{
    class Program
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

            //1.연결 객체 만들기 - Client
            OracleConnection conn = new OracleConnection(strConn);

            //2.데이터베이스 접속을 위한 연결
            conn.Open();

            //명령객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            //데이터 조회
            cmd.CommandText = "SELECT * FROM PhoneBook";
            //cmd.ExecuteNonQuery()

            //데이터 조회 결과를 리턴하는 DataReader객체를 만들어야 한다.
            OracleDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                //int id = rdr.GetInt32(0); //int나 number로 받을때 
                //int id = int.Parse(rdr.GetString(0));  // 0이 뜻하는 것은 컬럼의 순서 0부터 첫번째 컬럼
                //int id = int.Parse(rdr["ID"] as string); //Error
                int id = int.Parse(rdr["ID"].ToString());
                string name = rdr["NAME"] as string;
                string hp = rdr["HP"] as string;

                Console.WriteLine($"{id} : {name} : {hp}");
            }

            //리소스 반환
            conn.Close();
        }
    }
}
