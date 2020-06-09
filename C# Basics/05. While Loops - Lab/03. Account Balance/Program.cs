using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {

            int deposit = int.Parse(Console.ReadLine());

            int n = 0;
            double depositCount = 0;

            while (n < deposit)
            {
                n++;
                double oneDeposit = double.Parse(Console.ReadLine());

                if (oneDeposit <= 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                else
                    depositCount += oneDeposit;
                Console.WriteLine($"Increase: {oneDeposit:F2}");
            }

            Console.WriteLine($"Total: {depositCount:F2}");
        }
    }
}
