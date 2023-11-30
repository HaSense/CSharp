using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_query_select_oop
{
    /* 현재 클래스는 DB접속 및 관리와 관련된 내용을 작성하면 됩니다. */
    class DatabaseManager
    {
        private string connectionString;
        public DatabaseManager()
        {
            //차후에는 코드에 삽입보다 xml에 json 형태로 삽입하는 것도 좋습니다.
            connectionString = "Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)" +
                "(SERVICE_NAME=xe)));" +
                "User Id=c##scott;Password=tiger;";
        }

        /* 
         * 연결을 GetConnection으로 정의 하였습니다. conn함수 생각하시면 됩니다.
        */
        public OracleConnection GetConnection()
        {
            return new OracleConnection(connectionString);
        }
    }
}
