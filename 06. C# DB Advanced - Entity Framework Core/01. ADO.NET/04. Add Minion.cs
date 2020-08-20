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

                var minionInfo = Console.ReadLine().Split();
                var minionName = minionInfo[1];
                var minionAge = int.Parse(minionInfo[2]);
                var minionTown = minionInfo[3];

                var villainInput = Console.ReadLine().Split();
                var villainName = villainInput[1];

                var command = new SqlCommand($"SELECT COUNT(*) FROM Towns WHERE Name = '{minionTown}'", sqlConnection);

                if ((int)command.ExecuteScalar() == 0)
                {
                    command = new SqlCommand($"INSERT INTO Towns(Name) VALUES ('{minionTown}')", sqlConnection);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                command = new SqlCommand($"SELECT COUNT(*) FROM Villains WHERE Name = '{villainName}'", sqlConnection);

                if ((int)command.ExecuteScalar() == 0)
                {
                    command = new SqlCommand($"INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('{villainName}', 4)", sqlConnection);
                    command.ExecuteNonQuery();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                command = new SqlCommand($"SELECT Id FROM Towns WHERE Name = '{minionTown}'", sqlConnection);
                int townId = (int)command.ExecuteScalar();

                command = new SqlCommand($"INSERT INTO Minions(Name, Age, TownId) VALUES ('{minionName}', {minionAge}, {townId})", sqlConnection);
                command.ExecuteNonQuery();

                int villainId = (int)new SqlCommand($"SELECT Id FROM Villains WHERE Name = '{villainName}'", sqlConnection).ExecuteScalar();
                int minionId = (int)new SqlCommand($"SELECT Id FROM Minions WHERE Name = '{minionName}'", sqlConnection).ExecuteScalar();

                command = new SqlCommand($"INSERT INTO MinionsVillains VALUES ({minionId}, {villainId})", sqlConnection);
                command.ExecuteNonQuery();
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}
