using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] NSX = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int N = NSX[0];
            int S = NSX[1];
            int X = NSX[2];

            int[] arrayOfNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < N; i++)
            {
                queue.Enqueue(arrayOfNums[i]);
            }

            for (int i = 0; i < S; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(X))
            {
                Console.WriteLine("true");
            }
			
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
			
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
