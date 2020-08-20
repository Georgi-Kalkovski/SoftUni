using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@">>([A-Za-z]+)<<([0-9.]+)!([0-9]+)");

            string input = string.Empty;
            var matchingFurniture = new List<string>();
            double totalPrice = 0;

            while (true)
            {
                input = Console.ReadLine();
                MatchCollection matched = Regex.Matches(input, regex.ToString());
				
                if (input == "Purchase")
                {
                    break;
                }

                foreach (Match match in matched)
                {
                    matchingFurniture
                        .Add(match.Groups[1].Value);

                    totalPrice += 
                        double.Parse(match.Groups[2].Value) *
                        double.Parse(match.Groups[3].Value);
                }
            }

            Console.WriteLine("Bought furniture:");

            foreach (var furniture in matchingFurniture)
            {
                Console.WriteLine(furniture);
            }

            Console.WriteLine($"Total money spend: {totalPrice:F2}");
        }
    }
}
