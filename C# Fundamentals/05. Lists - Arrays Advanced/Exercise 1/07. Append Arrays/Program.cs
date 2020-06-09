using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split('|')
                .Reverse()
                .ToList();

            List<int> toNumbers = new List<int>();

            foreach (var str in input)
            {
                toNumbers.AddRange(str.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList());
            }

            Console.WriteLine(string.Join(" ", toNumbers));
        }
    }
}
