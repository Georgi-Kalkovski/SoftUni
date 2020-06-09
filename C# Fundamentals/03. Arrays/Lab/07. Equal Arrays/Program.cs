using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOne = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] arrayTwo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int sum = 0;

            for (int i = 0; i <= arrayOne.Length - 1; i++)
            {
                sum += arrayOne[i];

                if (arrayOne[i] != arrayTwo[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }
			
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
