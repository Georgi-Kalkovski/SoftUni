using System;
using System.Linq;
namespace _05._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int sum = 0;

            foreach (int number in array)
            {
                if (number % 2 == 0)
                {
                    sum += number;
                }
            }
			
            Console.WriteLine(sum);
        }
    }
}
