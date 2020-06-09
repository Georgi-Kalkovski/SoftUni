using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03._The_Isle_of_Man_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^([#|%|&|*|$])+(?<racer>[A-Za-z]+)+\1=(?<lengthOfGDK>\d+)+?\!\!(?<coordinatesOfGDK>.+)$");


            while (true)
            {
                string line = Console.ReadLine();

                Match match = regex.Match(line);

                if (match.Success)
                {
                    string racer = match.Groups["racer"].Value;
                    int lengthOfGTK = int.Parse(match.Groups["lengthOfGDK"].Value);
                    string coordinatesOfGDK = match.Groups["coordinatesOfGDK"].Value;

                    if (lengthOfGTK == coordinatesOfGDK.Length)
                    {
                        var decryptedCoordinatesOfGDK = string.Empty;
						
                        for (int i = 0; i < lengthOfGTK; i++)
                        {
                            decryptedCoordinatesOfGDK += (char)(coordinatesOfGDK[i] + lengthOfGTK);
                        }
						
                        Console.WriteLine($"Coordinates found! {racer} -> {decryptedCoordinatesOfGDK}");
                        return;
                    }
					
                    else
                    {
                        Console.WriteLine("Nothing found!");
                        continue;
                    }
                }
				
                else
                {
                    Console.WriteLine("Nothing found!");
                }

            }
        }
    }
}
