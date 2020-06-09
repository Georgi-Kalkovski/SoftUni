using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Queue<string> queue = new Queue<string>();
            Queue<string> paid = new Queue<string>();
			
            while (true)
            {
                input = Console.ReadLine();
				
                if (input == "End")
                {
                    int remaining = queue.Count;
					
                    for (int i = paid.Count;i>0;i--)
                    {
                        Console.WriteLine(paid.Peek());
                        paid.Dequeue();
                    }
					
                    Console.WriteLine($"{remaining} people remaining.");
                    break;
                }
				
                if (input != "Paid")
                {
                    queue.Enqueue(input);
                    continue;
                }
				
                else if (input == "Paid")
                {
                    foreach (var name in queue)
                    {
                        paid.Enqueue(name);
                    }
					
                    queue.Clear();
                }
            }
        }
    }
}
