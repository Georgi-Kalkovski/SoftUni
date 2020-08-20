using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boxesOfClothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            int rackCounter = 1;

            foreach (var box in boxesOfClothes)
            {
                if (stack.Sum() + box > rackCapacity)
                {
                    rackCounter++;
                    stack.Clear();
                    stack.Push(box);
                }
				
                else
                {
                    stack.Push(box);
                    
                }
            }
			
            Console.WriteLine(rackCounter);
        }
    }
}
