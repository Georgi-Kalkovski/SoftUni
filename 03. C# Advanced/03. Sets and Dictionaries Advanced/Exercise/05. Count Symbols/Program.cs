using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> letters = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                if (!letters.ContainsKey(text[i]))
                {
                    letters.Add(text[i], +1);
                }

                else
                {
                    letters[text[i]] += 1;
                }
            }

            foreach (var letter in letters)
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }
    }
}
