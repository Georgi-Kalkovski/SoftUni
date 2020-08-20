using System;
using System.Collections.Generic;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reverses = new Stack<char>();

            foreach (char ch in input)
            {
                reverses.Push(ch);
            }
			
            while (reverses.Count != 0)
            {
                Console.Write(reverses.Pop());
            }
			
            Console.WriteLine();
        }
    }
}
