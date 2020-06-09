using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> dict = new Dictionary<string, long>();

            while (true)
            {
                string firstInput = Console.ReadLine();

                if (firstInput == "stop")
                {
                    break;
                }

                long secondInput = long.Parse(Console.ReadLine());

                if (!dict.ContainsKey(firstInput))
                {
                    dict.Add(firstInput, secondInput);
                }
				
                else
                {
                    dict[firstInput] += secondInput;
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
