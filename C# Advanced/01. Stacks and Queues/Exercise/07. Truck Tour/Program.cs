using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            int index = 0;
            Queue<int> difference = new Queue<int>();

            for (int i = 0; i < pumpsCount; i++)
            {
                int[] pumpProps = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                difference.Enqueue(pumpProps[0] - pumpProps[1]);
            }
			
            while (true)
            {
                Queue<int> testQueue = new Queue<int>(difference);
                int fuel = -1;
				
                while (testQueue.Any())
                {
                    if (testQueue.Peek() > 0 && fuel == -1)
                    {
                        fuel = testQueue.Dequeue();
                        difference.Enqueue(difference.Dequeue());
                    }
					
                    else if (testQueue.Peek() < 0 && fuel == -1)
                    {
                        testQueue.Enqueue(testQueue.Dequeue());
                        difference.Enqueue(difference.Dequeue());
                        index++;
                    }
					
                    else
                    {
                        fuel += testQueue.Dequeue();
						
                        if (fuel < 0)
                        {
                            break;
                        }
                    }
                }
				
                if (fuel >= 0)
                {
                    Console.WriteLine(index);
                    return;
                }
				
                index++;
            }

        }
    }
}
