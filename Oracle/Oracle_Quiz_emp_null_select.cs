using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracleApp_Null
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strConn = "Data Source=(DESCRIPTION=" +
            "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
            "(HOST=127.0.0.1)(PORT=1521)))" +
            "(CONNECT_DATA=(SERVER=DEDICATED)" +
            "(SERVICE_NAME=xe)));" +
            "User Id=hr;Password=hr;";

            OracleConnection conn = null;
            OracleCommand cmd = null;
            OracleDataReader rdr = null;

            try
            {
                conn = new OracleConnection(strConn);
                conn.Open();

                cmd = new OracleCommand("SELECT * FROM emp", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int empno = rdr.GetInt32(rdr.GetOrdinal("EMPNO"));
                    string ename = rdr.IsDBNull(rdr.GetOrdinal("ENAME")) ? null : rdr.GetString(rdr.GetOrdinal("ENAME"));
                    string job = rdr.IsDBNull(rdr.GetOrdinal("JOB")) ? null : rdr.GetString(rdr.GetOrdinal("JOB"));
                    int? mgr = rdr.IsDBNull(rdr.GetOrdinal("MGR")) ? null : (int?)rdr.GetInt32(rdr.GetOrdinal("MGR"));
                    DateTime? hiredate = rdr.IsDBNull(rdr.GetOrdinal("HIREDATE")) ? null : (DateTime?)rdr.GetDateTime(rdr.GetOrdinal("HIREDATE"));
                    decimal sal = rdr.IsDBNull(rdr.GetOrdinal("SAL")) ? 0 : rdr.GetDecimal(rdr.GetOrdinal("SAL"));
                    decimal? comm = rdr.IsDBNull(rdr.GetOrdinal("COMM")) ? null : (decimal?)rdr.GetDecimal(rdr.GetOrdinal("COMM"));
                    int deptno = rdr.IsDBNull(rdr.GetOrdinal("DEPTNO")) ? 0 : rdr.GetInt32(rdr.GetOrdinal("DEPTNO"));

                    Console.WriteLine($"EMPNO: {empno}");
                    Console.WriteLine($"ENAME: {ename ?? "NULL"}");
                    Console.WriteLine($"JOB: {job ?? "NULL"}");
                    Console.WriteLine($"MGR: {(mgr.HasValue ? mgr.Value.ToString() : "NULL")}");
                    Console.WriteLine($"HIREDATE: {(hiredate.HasValue ? hiredate.Value.ToString("yyyy/MM/dd") : "NULL")}");
                    Console.WriteLine($"SAL: {sal}");
                    Console.WriteLine($"COMM: {(comm.HasValue ? comm.Value.ToString() : "NULL")}");
                    Console.WriteLine($"DEPTNO: {deptno}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Dispose();
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
}
