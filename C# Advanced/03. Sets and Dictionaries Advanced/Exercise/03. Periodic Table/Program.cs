using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCompounds = int.Parse(Console.ReadLine());

            SortedSet<string> compounds = new SortedSet<string>();

            for (int i = 0; i < numberOfCompounds; i++)
            {
                string[] compound = Console.ReadLine().Split();

                foreach (var element in compound)
                {
                    compounds.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", compounds));
        }
    }
}
