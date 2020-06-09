using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> dict = new SortedDictionary<string, int>();

            int shards = 0;
            int fragments = 0;
            int motes = 0;
            bool legendaryWasCreated = false;

            while (true)
            {
                var input = Console.ReadLine()
                .Split()
                .ToArray();

                for (int i = 1; i <= input.Length; i += 2)
                {
                    input[i] = input[i].ToLower();

                    if (!dict.ContainsKey(input[i]))
                    {
                        dict.Add(input[i], int.Parse(input[i - 1]));
                    }
					
                    else
                    {
                        dict[input[i]] += int.Parse(input[i - 1]);
                    }

                    if (input[i] == "shards") shards += int.Parse(input[i - 1]);
					
                    if (input[i] == "fragments") fragments += int.Parse(input[i - 1]);
					
                    if (input[i] == "motes") motes += int.Parse(input[i - 1]);

                    if (shards >= 250)
                    {
                        shards -= 250;
                        Console.WriteLine("Shadowmourne obtained!");
                        legendaryWasCreated = true;
                        break;
                    }
					
                    if (fragments >= 250)
                    {
                        fragments -= 250;
                        Console.WriteLine("Valanyr obtained!");
                        legendaryWasCreated = true;
                        break;
                    }
					
                    if (motes >= 250)
                    {
                        motes -= 250;
                        Console.WriteLine("Dragonwrath obtained!");
                        legendaryWasCreated = true;
                        break;
                    }
                }
				
                if (legendaryWasCreated)
                {
                    break;
                }
            }

            dict.Remove("shards");
            dict.Remove("fragments");
            dict.Remove("motes");

            SortedDictionary<string, int> remainingMats = new SortedDictionary<string, int>();

            remainingMats["shards"] = shards;
            remainingMats["fragments"] = fragments;
            remainingMats["motes"] = motes;

            foreach (KeyValuePair<string, int> item in remainingMats.OrderByDescending(key => key.Value))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
