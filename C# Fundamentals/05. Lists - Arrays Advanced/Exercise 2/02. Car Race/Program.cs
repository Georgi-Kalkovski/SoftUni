using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> leftRacer = new List<int>();
            List<int> rightRacer = new List<int>();

            for (int i = 0; i < input.Count / 2; i++)
            {
                leftRacer.Add(input[i]);
                rightRacer.Add(input[input.Count-i-1]);
            }

            double leftSum = 0.0;
            double rightSum = 0.0;

            for (int i = 0; i < input.Count / 2; i++)
            {
                if (leftRacer[i] == 0)
                {
                    leftSum *= 0.8;
                }
				
                else
                {
                    leftSum += leftRacer[i];
                }

                if (rightRacer[i] == 0)
                {
                    rightSum *= 0.8;
                }
				
                else
                {
                    rightSum += rightRacer[i];
                }
            }

            if (leftSum < rightSum)
            {
                Console.WriteLine($"The winner is left with total time: {leftSum}");
            }
			
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightSum}");
            }
        }
    }
}
