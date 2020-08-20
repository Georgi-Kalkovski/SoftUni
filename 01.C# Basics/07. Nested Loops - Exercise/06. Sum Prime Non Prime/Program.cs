using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            double sumOfPrimes = 0;
            double sumOfNonPrimes = 0;
            string number = string.Empty;

            while (number != "stop")
            {
                number = Console.ReadLine();

                if (number == "stop")
                    break;

                int digit = int.Parse(number);

                if (digit == 0)
                    continue;

                if (digit < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                if (digit == 2 || digit == 3 || digit == 5 || digit == 7 || digit == 11)
                {
                    sumOfPrimes += digit;
                }

                if(digit % 2 != 0 && digit != 1 && digit % 3 != 0 && digit % 5 != 0 && digit % 7 != 0 && digit % 11 != 0)
                {
                    sumOfPrimes += digit;
                }

                else
                {
                    sumOfNonPrimes += digit;
                }
            }
			
            Console.WriteLine($"Sum of all prime numbers is: {sumOfPrimes}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumOfNonPrimes}");
        }
    }
}
