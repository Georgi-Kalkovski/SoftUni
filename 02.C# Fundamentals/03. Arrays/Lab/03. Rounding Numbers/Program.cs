using System;
using System.Linq;

namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            foreach (double numbers in input)
            {
                int rounded = (int)Math.Round(numbers, MidpointRounding.AwayFromZero);
                Console.WriteLine($"{numbers} => {rounded}");
            }
        }
    }
}
