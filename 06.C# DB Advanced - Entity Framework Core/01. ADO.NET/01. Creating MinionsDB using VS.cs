using System;
using Microsoft.Data.SqlClient;

namespace Introduction_to_DB_Apps
{
    class Program
    {
        static void Main()
        {
           SqlConnection sqlConnection = new SqlConnection("Server = DESKTOP-GHV5K6M\\MSSQLSERVER01;" +
                                                            "Database=MinionsDB;" +
                                                            "Integrated Security=true");
            sqlConnection.Open();

            using (sqlConnection)
            {
                string queryCreateDB = "CREATE DATABASE MinionsDB";

                SqlCommand createDB = new SqlCommand(queryCreateDB, sqlConnection);

                createDB.ExecuteNonQuery();
            }
        }
    }
}
