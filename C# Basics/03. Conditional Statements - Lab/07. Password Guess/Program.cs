using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Password_Guess
{
    class Program
    {
        static void Main(string[] args)
        {

            string password = Console.ReadLine();
            // pishem na konzolata duma, koqto shte e parola

            if (password == "s3cr3t!P@ssw0rd")
            // ako parolata otgovarq na zadadenata parola v programata
            {
                Console.WriteLine("Welcome");
                // vadim na konzolata "Welcome"
            }

            else
            // v protiven sluhai
                Console.WriteLine("Wrong password!");
                // vadim na konzolata "Wrong password!"

        }
    }
}
