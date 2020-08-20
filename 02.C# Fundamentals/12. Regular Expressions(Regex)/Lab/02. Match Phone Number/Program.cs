using System;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var phones = Console.ReadLine();

            var regex = new Regex(@"(^| )\+\d{3}( |-)[0-9]\2[0-9]{3}\2[0-9]{4}\b");

            var currectPhones = regex.Matches(phones);

            Console.WriteLine(string.Join(",", currectPhones));
        }
    }
}
