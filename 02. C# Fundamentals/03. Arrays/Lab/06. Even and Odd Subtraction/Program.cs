using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int evenSum = 0;
            int oddSum = 0;

            foreach (int number in array)
            {
                if (number % 2 == 0)
                {
                    evenSum += number;
                }
				
                else
                {
                    oddSum += number;
                }
            }
			
            Console.WriteLine(evenSum - oddSum);
        }
    }
}
