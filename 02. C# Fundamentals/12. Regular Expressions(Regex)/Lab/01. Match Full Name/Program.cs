using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var regex = new Regex(@"(^| )\+359( |-)2\2[0-9]{3}\2[0-9]{4}\b");

            var matches = regex.Matches(text);

            Console.WriteLine(string.Join(",", matches));
        }
    }
}
