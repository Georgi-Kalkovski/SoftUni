using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                else if (command == "add")
                {
                    for(int i =0;i < numbers.Count;i++)
                    {
                        Func<List<int>, int> func = x => x[i] = x[i] + 1;
                        func(numbers);
                    }
                }
                else if (command == "multiply")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        Func<List<int>, int> func = x => x[i] = x[i] * 2;
                        func(numbers);
                    }
                }
                else if (command == "subtract")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        Func<List<int>, int> func = x => x[i] = x[i] - 1;
                        func(numbers);
                    }
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
            }
        }
    }
}
