using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var textLines = File.ReadAllLines("text.txt");
            var newTextLines = new List<string>(textLines);
            var symbols = new[] { '-', '\'', ',', '.', '!', '?' };

            for (int i = 0; i <= textLines.Length - 1; i++)
            {
                var symbolsCounter = 0;

                foreach (var symbol in symbols)
                {
                    if (textLines[i].Contains(symbol))
                    {
                        symbolsCounter++;
                    }
                }

                var lettersCounter = Regex.Matches(textLines[i], @"[a-zA-Z]").Count;

                newTextLines[i] = $"Line{i + 1}: {textLines[i]} ({lettersCounter})({symbolsCounter})";
            }

            File.WriteAllLines("output.txt", newTextLines);
        }
    }
}
