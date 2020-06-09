using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void AddWagon(List<int> input, List<string> command)
        {
            input.Add(int.Parse(command[1]));
        }
		
        static void AddPassengers(List<int> input, List<string> command, int maxCapacity)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] + int.Parse(command[0]) <= maxCapacity)
                {
                    input[i] += int.Parse(command[0]);
                    break;
                }
				
                else continue;
            }
        }
		
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                List<string> command = Console.ReadLine()
                    .Split()
                    .ToList();

                if (command[0] == "end")
                {
                    Console.WriteLine(string.Join(" ", input));
                    break;
                }
				
                if (command[0] == "Add") AddWagon(input, command);
				
                else AddPassengers(input, command,maxCapacity);
            }
        }
    }
}
