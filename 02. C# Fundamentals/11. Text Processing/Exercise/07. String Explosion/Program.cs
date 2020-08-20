using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine()
                .ToCharArray()
                .ToList();

            int strength = 0;
            int lineLength = line.Count();
			
            for (int i = 0; i < lineLength;i++)
            {

                if (line[i] == '>')
                {
                    strength += line[i + 1] - '0';
                    continue;
                }
				
                if (line[i] != '>' && strength > 0)
                {
                        line.RemoveAt(i);
                        lineLength--;
                        i--;
                        strength--;
                }
            }

            Console.WriteLine(string.Join("", line));
        }
    }
}
