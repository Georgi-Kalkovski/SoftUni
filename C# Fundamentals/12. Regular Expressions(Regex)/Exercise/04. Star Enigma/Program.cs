using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
namespace _3._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<StringBuilder> decryptedMessages = new List<StringBuilder>();
			
            for (int i = 0; i < n; i++)
            {
                string messages = Console.ReadLine();
                string patternKey = @"[sStTaArR]";
                Regex regex = new Regex(patternKey);
                MatchCollection matches = regex.Matches(messages);
                int countDeleteAscii = matches.Count;
                StringBuilder decryptMessage = new StringBuilder();
				
                for (int j = 0; j < messages.Length; j++)
                {
                    decryptMessage.Append(Convert.ToChar(messages[j] - countDeleteAscii));
                }
				
                decryptedMessages.Add(decryptMessage);
            }
			
            List<string> attacked = new List<string>();
            List<string> destryed = new List<string>();
			
            foreach (var item in decryptedMessages)
            {
                Regex reg = new Regex(@"@([a-zA-Z]+)[^@\-!:>]*:[0-9]+[^@\-!:>]*!([AD])![^@\-!:>]*->[0-9]+");
				
                if (reg.IsMatch(item.ToString()))
                {
                    string planetName = reg.Match(item.ToString()).Groups[1].Value;
                    string attackType = reg.Match(item.ToString()).Groups[2].Value;
					
                    if (attackType == "A")
                    {
                        attacked.Add(planetName);
                    }
					
                    else if (attackType == "D")
                    {
                        destryed.Add(planetName);
                    }
                }
            }
			
            if (attacked.Count == 0)
            {
                Console.WriteLine("Attacked planets: 0");
            }
			
            else
            {
                Console.WriteLine($"Attacked planets: {attacked.Count}");
				
                foreach (var item in attacked.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {item}");
                }
            }
			
            if (destryed.Count == 0)
            {
                Console.WriteLine("Destroyed planets: 0");
            }
			
            else
            {
                Console.WriteLine($"Destroyed planets: {destryed.Count}");
				
                foreach (var item in destryed.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {item}");
                }
            }
        }
    }
}