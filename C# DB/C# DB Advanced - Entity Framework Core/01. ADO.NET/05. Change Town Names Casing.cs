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

                var country = Console.ReadLine();

                var command =   $"SELECT t.Name " +
                                $"FROM Towns as t " +
                                $"JOIN Countries AS c ON c.Id = t.CountryCode " +
                                $"WHERE c.Name = @Country";

                var countryCommand = new SqlCommand(command, sqlConnection);
                countryCommand.Parameters.AddWithValue("Country", country);

                int townCounter = 0;

                if (countryCommand.ExecuteScalar()?.ToString() == null)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                using (var reader = countryCommand.ExecuteReader())
                {

                    List<string> changedTowns = new List<string>();

                    while (reader.Read())
                    {
                        var townNameBefore = reader["Name"].ToString();
                        var townNameAfter = reader["Name"].ToString().ToUpper().ToString();

                        if (townNameAfter == townNameBefore)
                        {
                            continue;
                        }

                        new SqlCommand($"UPDATE Towns SET Name = '{reader["Name"].ToString().ToUpper()}", sqlConnection);
                        changedTowns.Add(townNameAfter);
                        townCounter++;

                    }

                    if (townCounter == 0)
                    {
                        Console.WriteLine("No town names were affected.");
                    }
                    else
                    {
                        Console.WriteLine($"{townCounter} town names were affected.");
                        Console.WriteLine($"[{string.Join(", ",changedTowns)}]");
                    }
                }
            }
        }
    }
}
