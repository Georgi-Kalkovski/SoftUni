using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < N; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int command = input[0];
                
                if (command == 1)
                {
                    stack.Push(input[1]);
                    continue;
                }
				
                else if (command == 2)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
					
                    stack.Pop();
                    continue;
                }
				
                else if (command == 3 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());
                    continue;
                }
				
                else if (command == 4 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                    continue;
                }
            }
			
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
