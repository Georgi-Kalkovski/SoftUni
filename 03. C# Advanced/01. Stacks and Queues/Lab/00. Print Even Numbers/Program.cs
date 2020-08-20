using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(array);

            for (int i = queue.Count; i > 0; i--)
            {
                if (queue.Peek() % 2 == 0)
                {
                    queue.Enqueue(queue.Peek());
                    queue.Dequeue();
                }
				
                else if (queue.Peek() % 2 != 0)
                {
                    queue.Dequeue();
                }
            }
			
            Console.WriteLine(String.Join(", ", queue));
        }
    }
}
