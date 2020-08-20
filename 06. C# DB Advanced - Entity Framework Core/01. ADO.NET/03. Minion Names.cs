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

                var inputId = int.Parse(Console.ReadLine());

                var findVillainWithSameIdCommand = "SELECT [Name] FROM Villains WHERE Id = @Id";

                var findVillainWithSameId = new SqlCommand(findVillainWithSameIdCommand, sqlConnection);
                findVillainWithSameId.Parameters.AddWithValue("Id", inputId);

                if (findVillainWithSameId.ExecuteScalar()?.ToString() == null)
                {
                    Console.WriteLine($"No villain with ID {inputId} exists in the database.");
                    return;
                }

                using (var reader = findVillainWithSameId.ExecuteReader())
                {
                    reader.Read();
                    Console.WriteLine($"Villain: {reader["Name"]}");
                }
                
                var findMinionsInfoCommand = "SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum, m.Name, m.Age " +
                                             "FROM MinionsVillains AS mv " +
                                             "JOIN Minions As m ON mv.MinionId = m.Id " +
                                             "WHERE mv.VillainId = @Id " +
                                             "ORDER BY m.Name";

                var findMinionsInfo = new SqlCommand(findMinionsInfoCommand, sqlConnection);
                findMinionsInfo.Parameters.AddWithValue("Id", inputId);

                using (var reader = findMinionsInfo.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["Name"].ToString() == null)
                        {
                            Console.WriteLine("(no minions)");
                            continue;
                        }

                        Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                    }
                }
            }
        }
    }
}
