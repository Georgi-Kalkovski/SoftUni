using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> numStack = new Stack<int>(input);

            while (true)
            {
                string[] command = Console.ReadLine()
                    .ToLower()
                    .Split();

                if (command[0] == "end")
                {
                    break;
                }

                else if (command[0] == "add")
                {
                    numStack.Push(int.Parse(command[1]));
                    numStack.Push(int.Parse(command[2]));
                    continue;
                }

                else if (command[0] == "remove")
                {
                    if (int.Parse(command[1]) > numStack.Count)
                    {
                        continue;
                    }
					
                    for (int i = 0; i < int.Parse(command[1]); i++)
                    {
                        numStack.Pop();
                    }
                    continue;
                }
            }
			
            int sum = 0;
			
            foreach (int num in numStack)
            {
                sum += num;
            }
			
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
