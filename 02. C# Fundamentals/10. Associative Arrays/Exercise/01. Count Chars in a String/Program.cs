using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().Replace(" ", "");
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach (char ch in input)
            {
                if (!dict.ContainsKey(ch))
                {
                    dict.Add(ch, 1);
                }
				
                else
                {
                    dict[ch] += 1;
                }
            }
			
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
