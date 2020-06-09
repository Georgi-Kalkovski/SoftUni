using System;
using System.Collections.Generic;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());

            var continents = new Dictionary<string, Dictionary<string, List<string>>>();
            
            for (int i = 0; i < inputLines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new Dictionary<string, List<string>>();
                    continents[continent].Add(country, new List<string>{ city});
                    continue;
                }

                if (continents.ContainsKey(continent) && !continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string> { city });
                    continue;
                }

                if (continents.ContainsKey(continent) && 
                    continents[continent].ContainsKey(country) && 
                    !continents[continent].ContainsValue(new List<string>{ city}))
                {
                    continents[continent][country].Add(city);
                    continue;
                }
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)

                {
                    Console.Write($"  {country.Key} -> ");
                    Console.Write(string.Join(", ", country.Value));
                    Console.WriteLine();
                }
            }
        }
    }
}
