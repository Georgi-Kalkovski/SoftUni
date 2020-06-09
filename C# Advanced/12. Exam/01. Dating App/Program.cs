using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] males = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] females = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> femaleQueue = new Queue<int>(females);
            Stack<int> maleStack = new Stack<int>(males);

            int matchesCount = 0;

            while (true)
            {
                if (femaleQueue.Count == 0 || maleStack.Count() == 0)
                {
                    break;
                }
                
                if (femaleQueue.Peek() == 0)
                {
                    femaleQueue.Dequeue();
                    continue;
                }

                if (maleStack.Peek() == 0)
                {
                    maleStack.Pop();
                    continue;
                }

                if (femaleQueue.Peek() % 25 == 0)
                {
                    femaleQueue.Dequeue();
                    femaleQueue.Dequeue();
                    continue;
                }

                if (maleStack.Peek() % 25 == 0)
                {
                    maleStack.Pop();
                    maleStack.Pop();
                    continue;
                }

                if (femaleQueue.Peek() == maleStack.Peek())
                {
                    matchesCount++;
                    femaleQueue.Dequeue();
                    maleStack.Pop();
                }

                else
                {
                    femaleQueue.Dequeue();
                    int reducingMaleValue = maleStack.Pop() - 2;
                    maleStack.Push(reducingMaleValue);
                }
            }

            Console.WriteLine($"Matches: {matchesCount}");

            if (maleStack.Count > 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", maleStack)}");
            }
            else
            {
                Console.WriteLine($"Males left: none");
            }

            if (femaleQueue.Count > 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", femaleQueue)}");
            }
            else
            {
                Console.WriteLine($"Females left: none");
            }
        }
    }
}
