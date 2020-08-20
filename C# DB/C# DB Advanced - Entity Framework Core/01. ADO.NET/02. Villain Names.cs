using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

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

                var selectVillainsCommand = "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount " +
                                            "FROM Villains AS v " +
                                            "JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                                            "GROUP BY v.Id, v.Name " +
                                            "HAVING COUNT(mv.VillainId) > 3 " +
                                            "ORDER BY COUNT(mv.VillainId) ";

                var countOfMinionsPerVillain = new SqlCommand(selectVillainsCommand, sqlConnection);

                using (SqlDataReader reader = countOfMinionsPerVillain.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var villainName = reader["Name"].ToString();
                        var minionsCounter = (int)reader["MinionsCount"];
                        Console.WriteLine($"{villainName} - {minionsCounter}");
                    }
                }
            }
        }
    }
}
