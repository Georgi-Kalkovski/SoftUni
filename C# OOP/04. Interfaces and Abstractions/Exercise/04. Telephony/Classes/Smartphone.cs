using System;
using System.Linq;

namespace Telephony
{
    public class Smartphone : Call, Browse
    {
        private string[] phoneNumbers;
        private string[] sites;

        public Smartphone(string[] phoneNumbers, string[] sites)
        {
            PhoneNumbers = phoneNumbers;
            Sites = sites;
        }

        public string[] PhoneNumbers
        {
            get { return phoneNumbers; }
            set { phoneNumbers = value; }
        }

        public string[] Sites
        {
            get { return sites; }
            set { sites = value; }
        }

        public void Calling()
        {
            foreach (var number in PhoneNumbers)
            {
                if (number.All(char.IsDigit))
                {
                    Console.WriteLine($"Calling... {number}");
                    continue;
                }
                Console.WriteLine("Invalid number!");
            }
        }

        public void Browsing()
        {
            foreach (var site in Sites)
            {
                if (site.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }
                Console.WriteLine($"Browsing: {site}!");
            }
        }
    }
}
