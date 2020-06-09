using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            double endPrice = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift")
                {
                    break;
                }

                var regex = new Regex(@"\%(?<customerName>[A-Z][a-z]+)\%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+.\d*)\$");

                MatchCollection matches = Regex.Matches(input, regex.ToString());

                foreach (Match match in matches)
                {
                    var customerName = match.Groups["customerName"].Value;
                    var product = match.Groups["product"].Value;
                    var count = match.Groups["count"].Value;
                    var price = match.Groups["price"].Value;

                    double totalPrice = int.Parse(count) * double.Parse(price);

                    Console.WriteLine($"{customerName}: {product} - {totalPrice:F2}");

                    endPrice += totalPrice;
                }
            }
			
            Console.WriteLine($"Total income: {endPrice:F2}");
        }
    }
}
