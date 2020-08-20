using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<int> deviders = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToList();

            List<int> numbers = new List<int>();
            for (int i = 1; i <= length; i++)
            {
                if (DevidersInfo(i, deviders))
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static bool DevidersInfo(int n, List<int> deviders)
        {
            bool isTrue = true;
            foreach (int divaider in deviders)
            {
                if (n % divaider != 0)
                {
                    isTrue = false;
                }
            }
            return isTrue;
        }
    }
}