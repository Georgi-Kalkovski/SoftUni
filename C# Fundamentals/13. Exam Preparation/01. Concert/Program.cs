using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            var bands = new Dictionary<string, List<string>>();
            var bandsTime = new Dictionary<string, int>();
            var totalTime = 0;
            var finalBand = string.Empty;
			
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split("; ");

                if (input[0] == "start of concert")
                {
                    finalBand = Console.ReadLine();
                    break;
                }

                var command = input[0];

                if (command == "Add")
                {
                    var bandName = input[1];
                    var members = input[2].ToString().Split(", ").ToList();

                    if (bands.ContainsKey(bandName))
                    {
                        foreach (var member in members)
                        {
                            if (!bands[bandName].Contains(member))
                            {
                                bands[bandName].Add(member);
                            }
                        }
						
                        continue;
                    }
                    bands.Add(bandName, new List<string>(members));

                }
				
                if (command == "Play")
                {
                    var bandName = input[1];
                    var time = input[2];
                    totalTime += int.Parse(time);
					
                    if (!bandsTime.ContainsKey(bandName))
                    {
                        bandsTime.Add(bandName, int.Parse(time));
                        continue;
                    }
					
                    if (bandsTime.ContainsKey(bandName))
                    {
                            bandsTime[bandName] += int.Parse(time);
                            continue;
                    }
                }
            }

            var orderedBandsTime = bandsTime.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
            Console.WriteLine($"Total time: {totalTime}");
			
            foreach (var band in orderedBandsTime)
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            if (bands.ContainsKey(finalBand))
            {
                Console.WriteLine($"{finalBand}");

                foreach (var band in bands.Where(x => x.Key == finalBand))
                {
                    foreach (var members in band.Value)
                    {
                            Console.WriteLine($"=> {members.ToString()}");
                    }
                }
            }
        }
    }
}
