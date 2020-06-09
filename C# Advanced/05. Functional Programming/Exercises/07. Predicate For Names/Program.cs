using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int allowedChars = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split();

                Console.WriteLine(string.Join("\n", names.Where(x => x.Length <= allowedChars)));
        }
    }
}
