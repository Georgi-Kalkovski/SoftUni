using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();
            
            bool isParty = false;
            do
            {
                string currentGuest = Console.ReadLine();

                if (currentGuest == "END")
                {
                    break;
                }
                if (currentGuest == "PARTY")
                {
                    isParty = true;
                    continue;
                }
                if (isParty)
                {
                    if (vipGuests.Contains(currentGuest))
                    {
                        vipGuests.Remove(currentGuest);
                    }
                    else if (regularGuests.Contains(currentGuest))
                    {
                        regularGuests.Remove(currentGuest);
                    }
                    continue;
                }
                if (Char.IsDigit(currentGuest[0]))
                {
                    vipGuests.Add(currentGuest);
                }
                else
                {
                    regularGuests.Add(currentGuest);
                }
            }
            while (true);

            int numberOfComingGuests = vipGuests.Count + regularGuests.Count;
            Console.WriteLine(numberOfComingGuests);
            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
