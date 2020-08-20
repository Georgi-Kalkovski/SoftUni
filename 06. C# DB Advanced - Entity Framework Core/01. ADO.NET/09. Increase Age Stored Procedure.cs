using Microsoft.Data.SqlClient;
using System;

namespace Introduction_to_DB_Apps
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnection sqlConnection = new SqlConnection("Server = DESKTOP-GHV5K6M\\MSSQLSERVER01;" +
                                                            "Database=MinionsDB;" +
                                                            "Integrated Security=true");

            int id = int.Parse(Console.ReadLine());

            using (sqlConnection)
            {
                sqlConnection.Open();

                var command = new SqlCommand($"EXEC usp_GetOlder {id}", sqlConnection);
                command.ExecuteNonQuery();

                command = new SqlCommand($"SELECT * " +
                                         $"FROM Minions " +
                                         $"WHERE Id = {id}", sqlConnection);
                var reader = command.ExecuteReader();

                using (reader)
                {
                    reader.Read();
                    Console.WriteLine($"{(string)reader["Name"]} - {(int)reader["Age"]} years old");
                }
            }
        }
    }
}
