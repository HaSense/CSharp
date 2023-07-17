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

        using (OracleConnection conn = new OracleConnection(strConn))
        {
            conn.Open();

            using (OracleCommand cmd = new OracleCommand("SELECT * FROM PhoneBook", conn))
            {
                using (OracleDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        if (!rdr.IsDBNull(rdr.GetOrdinal("ID")))
                        {
                            int id = rdr.GetInt32(rdr.GetOrdinal("ID"));
                            string name = Convert.ToString(rdr["NAME"]);
                            string hp = Convert.ToString(rdr["HP"]);

                            Console.WriteLine($"{id} : {name} : {hp}");
                        }
                    }
                }
            }
        }
    }
}
