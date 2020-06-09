using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03._Emoji_Sumator
{
    class Program
    {
        static void Main()
        {
            var firstLine = Console.ReadLine();
            var emojiCode = Console.ReadLine().Split(":");

            var power = 0;
            var listOfEmojis = new List<string>();

            var patternForEmoji = @"(?<=[\s])(?<emoji>:[a-z]{4,}:)(?=[\s,.!?])";
			
            if (Regex.IsMatch(firstLine, patternForEmoji))
            {
                var matches = Regex.Matches(firstLine, patternForEmoji);
				
                foreach (Match match in matches)
                {
                    var emoji = match.Groups["emoji"].Value;
                    listOfEmojis.Add(emoji);
					
                    for (int i = 1; i < emoji.Length - 1; i++)
                    {
                        power += emoji[i];
                    }
                }
            }

            var givenEmoji = string.Empty;
			
            for (int i = 0; i < emojiCode.Length; i++)
            {
                var symbol = (char)(int.Parse(emojiCode[i]));
                givenEmoji += symbol;
            }

            for (int i = 0; i < listOfEmojis.Count; i++)
            {
                var currentEmoji = listOfEmojis[i].Remove(0, 1);
                currentEmoji = currentEmoji.Remove(currentEmoji.Length - 1, 1);
				
                if (currentEmoji == givenEmoji)
                {
                    power *= 2;
                    break;
                }
            }

            if (listOfEmojis.Count > 0)
            {
                Console.WriteLine($"Emojis found: {string.Join(", ", listOfEmojis)}");
            }

            Console.WriteLine($"Total Emoji Power: {power}");
        }
    }
}