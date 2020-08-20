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

                var villainId = Console.ReadLine();

                SqlCommand command = new SqlCommand($"SELECT Id " +
                                                    $"FROM Villains " +
                                                    $"WHERE Id = {villainId}", sqlConnection);

                if (command.ExecuteScalar()?.ToString() == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                command = new SqlCommand($"SELECT COUNT(*) " +
                                         $"FROM MinionsVillains " +
                                         $"WHERE VillainId = {villainId}", sqlConnection);
                int minionsCount = (int)command.ExecuteScalar();

                command = new SqlCommand($"DELETE " +
                                         $"FROM MinionsVillains " +
                                         $"WHERE VillainId = {villainId}", sqlConnection);
                command.ExecuteNonQuery();

                command = new SqlCommand($"SELECT Name " +
                                         $"FROM Villains" +
                                         $" WHERE Id = {villainId}", sqlConnection);
                string villainName = (string)command.ExecuteScalar();

                command = new SqlCommand($"DELETE " +
                                         $"FROM Villains " +
                                         $"WHERE Id = {villainId}", sqlConnection);
                command.ExecuteNonQuery();

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{minionsCount} minions were released.");
            }
        }
    }
}
