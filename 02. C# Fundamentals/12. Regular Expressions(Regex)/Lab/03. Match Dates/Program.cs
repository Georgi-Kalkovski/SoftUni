using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            var datesString = Console.ReadLine();

            var regex = new Regex(@"(?<day>[0-9]{2})(-|\/|.)(?<month>[A-Z][a-z]{2})\1(?<year>[0-9]{4})");

            var dates = regex.Matches(datesString);

            foreach (Match date in dates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
