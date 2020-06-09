using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(orders);
            int biggestOrder = queue.Max();
            int queueNum = orders.Count();

            for(int customer = 0; customer< queueNum; customer++)
            {
                if (quantityOfFood - queue.Peek() < 0)
                {
                    Console.WriteLine(biggestOrder);
                    Console.Write($"Orders left:");
					
                    for (int j = customer; j <= queueNum; customer++)
                    {
                        if (customer == queueNum)
                        {
                            return;
                        }
						
                        Console.Write(" " + orders[customer]);
                    }
                }
				
                quantityOfFood -= queue.Peek();
                queue.Enqueue(queue.Dequeue());
            }

            Console.WriteLine(biggestOrder);
            Console.WriteLine("Orders complete");
        }
    }
}
