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

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < N; i++)
            {
                stack.Push(arrayOfNums[i]);
            }

            for (int i = 0; i < S; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(X))
            {
                Console.WriteLine("true");
            }
			
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
			
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
