using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Feed_the_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<string, int>();
            var areas = new Dictionary<string, int>();
            string[] input = Console.ReadLine().Split(":");

            while (input[0] != "Last Info")
            {
                string command = input[0];
                string animalName = input[1];
                string area = input[3];

                if (command == "Add")
                {
                    int dailyFoodLimit = int.Parse(input[2]);
					
                    if (!dic.ContainsKey(animalName))
                    {
                        dic.Add(animalName, dailyFoodLimit);
						
                        if (!areas.ContainsKey(area))
                        {
                            areas.Add(area, 0);
                        }
                        areas[area]++;
                    }
					
                    else
                    {
                        dic[animalName] += dailyFoodLimit;
                    }
                }
				
                else
                {
                    int food = int.Parse(input[2]);
					
                    if (dic.ContainsKey(animalName))
                    {
                        dic[animalName] -= food;
						
                        if (dic[animalName] <= 0)
                        {
                            Console.WriteLine($"{dic.FirstOrDefault(x => x.Value == dic[animalName]).Key} was successfully fed");
                            dic.Remove(animalName);
                            areas[area]--;
                        }
                    }
                }
				
                input = Console.ReadLine().Split(":");
            }

            Console.WriteLine("Animals:");

            foreach (var k in dic.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{k.Key} -> {k.Value}g");
            }

            Console.WriteLine("Areas with hungry animals:");

            foreach (var k in areas.OrderByDescending(x => x.Value).Where(x => x.Value != 0))
            {
                Console.WriteLine($"{k.Key} : {k.Value}");
            }
        }
    }
}