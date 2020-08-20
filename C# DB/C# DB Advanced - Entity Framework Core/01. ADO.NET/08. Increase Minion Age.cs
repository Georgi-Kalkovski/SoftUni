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


            using (sqlConnection)
            {
                sqlConnection.Open();

                var input = Console.ReadLine().Split();

                for (int i = 0; i < input.Length; i++)
                {
                    var command = new SqlCommand($" UPDATE Minions " +
                                                $"SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1 " +
                                                $"WHERE Id = {int.Parse(input[i])}", sqlConnection).ExecuteNonQuery();


                }
                var result = new SqlCommand("SELECT Name, Age FROM Minions", sqlConnection);
                SqlDataReader reader = result.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    Console.WriteLine($" {reader["Name"]} {reader["Age"]}");
                }
            }
        }
    }
}
