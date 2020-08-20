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

            List<string> initialOrderOfMinions = new List<string>();
            List<string> arrangedOrderOfMinions = new List<string>();

            using (sqlConnection)
            {
                sqlConnection.Open();

                var command = new SqlCommand("SELECT Name FROM Minions", sqlConnection);

                var reader = command.ExecuteReader();

                using (reader)
                {
                    if (!reader.HasRows)
                    {
                        return;
                    }

                    while (reader.Read())
                    {
                        initialOrderOfMinions.Add((string)reader["Name"]);
                    }
                }
            }

            while (initialOrderOfMinions.Count > 0)
            {

                arrangedOrderOfMinions.Add(initialOrderOfMinions[0]);
                initialOrderOfMinions.RemoveAt(0);

                if (initialOrderOfMinions.Count > 0)
                {
                    arrangedOrderOfMinions.Add(initialOrderOfMinions[initialOrderOfMinions.Count - 1]);
                    initialOrderOfMinions.RemoveAt(initialOrderOfMinions.Count - 1);
                }
            }

            foreach (var minion in arrangedOrderOfMinions)
            {
                Console.WriteLine(minion);
            }
        }
    }
}
