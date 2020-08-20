using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex regex = new Regex(@"^([$%])+(?<tag>[A-Z][a-z]{3,})\1: (\[(?<charOne>\d+)\]\|)(\[(?<charTwo>\d+)\]\|)(\[(?<charThree>\d+)\]\|)$");
            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] inputSplit = input.Split(": ");

                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    string tag = match.Groups["tag"].Value;
                    int charOne = int.Parse(match.Groups["charOne"].Value);
                    int charTwo = int.Parse(match.Groups["charTwo"].Value);
                    int charThree = int.Parse(match.Groups["charThree"].Value);
                    char firstChar = Convert.ToChar(charOne);
                    char secondChar = Convert.ToChar(charTwo);
                    char thirdChar = Convert.ToChar(charThree);
                    string finalString = firstChar.ToString() + secondChar.ToString() + thirdChar.ToString();
                    Console.WriteLine($"{tag}: {finalString}");
                }
				
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
