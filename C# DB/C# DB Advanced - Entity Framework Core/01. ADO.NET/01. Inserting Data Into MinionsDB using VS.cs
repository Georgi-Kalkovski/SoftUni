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

                var insertIntoCountries = "INSERT INTO Countries([Name]) " +
                    "VALUES" +
                    "('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')";

                var insertIntoTowns = "INSERT INTO Towns([Name], CountryCode) " +
                    "VALUES" +
                    "('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)";

                var insertIntoMinions = "INSERT INTO Minions(Name, Age, TownId) " +
                    "VALUES" +
                    "('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)";

                var insertIntoEvilnessFactors = "INSERT INTO EvilnessFactors(Name) " +
                    "VALUES" +
                    "('Super good'),('Good'),('Bad'),('Evil'),('Super evil')";

                var insertIntoVillains = "INSERT INTO Villains(Name, EvilnessFactorId) " +
                    "VALUES" +
                    "('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)";

                var insertIntoVillainsMinions = "INSERT INTO MinionsVillains(MinionId, VillainId) " +
                    "VALUES" +
                    "(4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)";

                var insertedData = new List<string>();
                insertedData.Add(insertIntoCountries);
                insertedData.Add(insertIntoTowns);
                insertedData.Add(insertIntoMinions);
                insertedData.Add(insertIntoEvilnessFactors);
                insertedData.Add(insertIntoVillains);
                insertedData.Add(insertIntoVillainsMinions);

                foreach (var insert in insertedData)
                {
                    SqlCommand insertSqlCommand = new SqlCommand(insert, sqlConnection);
                    int result = (int)insertSqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Inserted Rows: " + result);
                }
            }
        }
    }
}
