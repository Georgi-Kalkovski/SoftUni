using System;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();
            Action<string> action = x => Console.WriteLine(string.Join("\n", x.Split().ToArray()));
            action(names);
        }
    }
}
