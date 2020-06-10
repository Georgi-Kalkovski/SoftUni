namespace Telephony
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var phoneNumbers = Console.ReadLine().Split().ToArray();
            var sites = Console.ReadLine().Split().ToArray();

            Smartphone smartphone = new Smartphone(phoneNumbers, sites);

            smartphone.Calling();
            smartphone.Browsing();
        }
    }
}
