using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();

            List<int> newList = new List<int>(numbers.Count);

            int givenInteger = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ", numbers
                .Where(x=>x % givenInteger != 0)));
        }
    }
}
