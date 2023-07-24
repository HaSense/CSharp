using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Log5Oracle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * SEQ_LOG
             * Create Table LogTable(
                 LOGID NUMBER(4) PRIMARY KEY,
                 LOGTIME VARCHAR2(30) NOT NULL,
                 LOGMESSAGE VARCHAR2(50) NOT NULL
                );
                COMMIT;
              
               INSERT INTO LogTable VALUES (SEQ_LOG.NEXTVAL, :LOGTIME, :LOGMESSAGE)
             
               시퀀스는 만들었다고 가정 이름 SEQ_LOG
             */
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
          
            OracleParameter LogTime = new OracleParameter("LOGTIME", System.DateTime.Now.ToString());
            OracleParameter LogMessage = new OracleParameter("LOGMESSAGE", "정상동작중");
            //파라미터 초기화를 하지 않으면 NullPointException 발생
            cmd.Parameters.Add(LogTime);
            cmd.Parameters.Add(LogMessage);

            for (int i = 0; i < 5; i++)
            {
                cmd.CommandText = "INSERT INTO LOGTABLE (LOGID, LOGTIME, LOGMESSAGE) " +
                                    "VALUES (SEQ_LOG.NEXTVAL, :LOGTIME, :LOGMESSAGE)";

                LogTime.Value = System.DateTime.Now.ToString();
                LogMessage.Value = "정상동작중";

                cmd.ExecuteNonQuery();
                
                Thread.Sleep(5000);
            }

            cmd.Dispose(); //또는 Close()
        }
    }
}
