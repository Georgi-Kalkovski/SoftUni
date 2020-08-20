using System;
using System.Linq;
using System.Collections.Generic;

namespace _0_5DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            List<int> drums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> price = new List<int>();
            price.AddRange(drums);

            string command = string.Empty;

            while (true)
            {
                command = Console.ReadLine();
				
                if (command == "Hit it again, Gabsy!") break;
                int hit = int.Parse(command);
				
                for (int i = 0; i < drums.Count; i++)
                {
                    drums[i] -= hit;
					
                    if (drums[i] <= 0)
                    {
                        if (budget - (price[i] * 3) >= 0)
                        {
                            budget = budget - (price[i] * 3);
                            drums[i] = price[i];
                        }
                    }
                }

                for (int i = 0; i < drums.Count; i++)
                {
                    if (drums[i] <= 0)
                    {
                        drums.Remove(drums[i]);
                        price.Remove(price[i]);
                    }
                }
            }
			
            foreach (var drum in drums)
            {
                Console.Write(drum + " ");
            }
			
            Console.WriteLine();
            Console.WriteLine($"Gabsy has {budget:f2}lv.");
        }
    }
}