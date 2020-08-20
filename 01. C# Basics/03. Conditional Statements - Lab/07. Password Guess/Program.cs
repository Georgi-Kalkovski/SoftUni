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

            if (password == "s3cr3t!P@ssw0rd")
            {
                Console.WriteLine("Welcome");
            }

            else
                Console.WriteLine("Wrong password!");

        }
    }
}
