using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Concatenate_Data
{
    class Program
    {
        static void Main(string[] args)
        {

            string firstName = Console.ReadLine();
            // pishem na konzolata string (ime)
            string lastName = Console.ReadLine();
            // pishem na konzolata string (familiq)
            int age = int.Parse(Console.ReadLine());
            // pishem na konzolata string (godini)
            string town = Console.ReadLine();
            // pishem na konzolata string (grad)

            Console.WriteLine($"You are {firstName} {lastName}, a {age}-years old person from {town}.");
            // vadim na konzolata text s vuvedenite danni ot konzolata po-rano
        }
    }
}
