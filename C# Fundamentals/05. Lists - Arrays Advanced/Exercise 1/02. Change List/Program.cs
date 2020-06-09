using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                List<string> command = Console.ReadLine()
                    .Split()
                    .ToList();

                if (command[0] == "Delete")
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        input.Remove(int.Parse(command[1]));
                    }
                }
				
                if (command[0] == "Insert")
                {
                    input.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }
				
                if (command[0] == "end")
                {
                    Console.WriteLine(string.Join(" ", input));
                    break;
                }
            }
        }
    }
}
