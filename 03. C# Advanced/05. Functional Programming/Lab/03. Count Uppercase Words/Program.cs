using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console
                .ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .ToArray();

            Console
                .WriteLine(string
                  .Join("\n", text
                    .Where(x=>x[0]
                    .ToString() == x[0]
                    .ToString()
                    .ToUpper())));
        }
    }
}
