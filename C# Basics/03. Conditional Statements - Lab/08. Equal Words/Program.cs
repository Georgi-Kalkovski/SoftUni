using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Equal_Words
{
    class Program
    {
        static void Main(string[] args)
        {

            string wordOne = Console.ReadLine();
            // vadim na konzolata duma
            string wordTwo = Console.ReadLine();
            // vadim na konzolta vtora duma
            wordOne = wordOne.ToLower();
            // pravim golemite bukvi na malki
            wordTwo = wordTwo.ToLower();
            // pravim golemite bukvi na malki

            if (wordOne == wordTwo)
            // ako purva duma i vtora duma sa ednakvi
                Console.WriteLine("yes");
                // vadm na konzolata "yes"

            else
            // v protiven sluchai
                Console.WriteLine("no");
                // vadim na konzolata "no"

        }
    }
}
