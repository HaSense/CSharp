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

        OracleConnection conn = null;
        OracleCommand cmd = null;
        OracleDataReader rdr = null;

        try
        {
            conn = new OracleConnection(strConn);
            conn.Open();

            string query = "SELECT * FROM PhoneBook";
            cmd = new OracleCommand(query, conn);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                if (!rdr.IsDBNull(rdr.GetOrdinal("ID")))
                {
                    int id = rdr.GetInt32(rdr.GetOrdinal("ID"));
                    string name = rdr.IsDBNull(rdr.GetOrdinal("NAME")) ? null : rdr.GetString(rdr.GetOrdinal("NAME"));
                    string hp = rdr.IsDBNull(rdr.GetOrdinal("HP")) ? null : rdr.GetString(rdr.GetOrdinal("HP"));

                    Console.WriteLine($"{id} : {name} : {hp}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
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
