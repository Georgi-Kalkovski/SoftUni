using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split("|")
                .ToList();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split();

                string command = input[0];

                if (command == "Yohoho!")
                {
                    break;
                }
				
                else if (command == "Loot")
                {
                    for (int i =1;i < input.Length;i++)
                    {
                        if (!line.Contains(input[i]))
                        {
                            line.Insert(0, input[i]);
                        }
                    }
                }
				
                else if (command == "Drop")
                {
                    int index = int.Parse(input[1]);
                    if (line.Count < index || index < 0)
                    {
                        continue;
                    }
					
                    else
                    {
                        string item = line[index];
                        line.Add(item);
                        line.RemoveAt(index);
                    }
                }
				
                else if (command == "Steal")
                {
                    int count = int.Parse(input[1]);

                    if (count > line.Count)
                    {
                        Console.WriteLine(string.Join(", ", line));
                        line.RemoveRange(0, line.Count);
                    }
					
                    else
                    {
                        Console.WriteLine(string.Join(", ", line.TakeLast(count)));
                        line.RemoveRange(line.Count - count, count);
                    }
                }
            }
			
            double sum = 0;

            for (int i = 0; i < line.Count; i++)
            {
                sum += line[i].Length;
            }
			
            if (sum > 0)
            {
                sum = sum / line.Count;
                Console.WriteLine($"Average treasure gain: {sum:F2} pirate credits.");
            }
			
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
