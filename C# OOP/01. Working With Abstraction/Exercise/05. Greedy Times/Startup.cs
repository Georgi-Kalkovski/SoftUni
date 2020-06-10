namespace GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var bag = new Dictionary<string, Dictionary<string, long>>();

            long bagCapacity = long.Parse(Console.ReadLine());

            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    
            long totalGold = 0;
            long totalGems = 0;
            long totalCash = 0;

            for (int i = 0; i < input.Length; i += 2)
            {
                string item = input[i];
                long amount = long.Parse(input[i + 1]);

                string type = string.Empty;

                if (item.Length == 3)
                {
                    type = "Cash";
                }

                else if (item.ToLower().EndsWith("gem"))
                {
                    type = "Gem";
                }

                else if (item.ToLower() == "gold")
                {
                    type = "Gold";
                }

                if (type == "")
                {
                    continue;
                }

                else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + amount)
                {
                    continue;
                }

                switch (type)
                {
                    case "Gem":
                        if (!bag.ContainsKey(type))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (amount > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[type].Values.Sum() + amount > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(type))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (amount > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[type].Values.Sum() + amount > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(type))
                {
                    bag[type] = new Dictionary<string, long>();
                }

                if (!bag[type].ContainsKey(item))
                {
                    bag[type][item] = 0;
                }

                bag[type][item] += amount;
                if (type == "Gold")
                {
                    totalGold += amount;
                }
                else if (type == "Gem")
                {
                    totalGems += amount;
                }
                else if (type == "Cash")
                {
                    totalCash += amount;
                }
            }

            foreach (var item in bag)
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");

                foreach (var item2 in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}