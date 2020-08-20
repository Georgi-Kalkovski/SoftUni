using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList()
                 .ToArray();

            Func<int, int, int> comparer = (x, y) =>
           Math.Abs(x % 2) == Math.Abs(y % 2) ? (x == y ? 0 : (x < y ? -1 : 1)) : (Math.Abs(x % 2) == 0 ? -1 : 1);

            Array.Sort(numbers, (x, y) => comparer(x, y));

            Console.WriteLine(String.Join(" ", numbers));

        }
    }
}
