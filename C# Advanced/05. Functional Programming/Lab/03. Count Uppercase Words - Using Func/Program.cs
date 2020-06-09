using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> filterUppercase = c => Char.IsUpper(c[0]);

            Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(filterUppercase)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
