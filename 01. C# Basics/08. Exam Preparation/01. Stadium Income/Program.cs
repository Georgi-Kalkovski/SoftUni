using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Stadium_Income
{
    class Program
    {
        static void Main(string[] args)
        {

            int sector = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());

            double totalIncome = capacity * ticketPrice;
            double singleSectorIncome = totalIncome / sector;
            double moneyForCharity = (totalIncome - (singleSectorIncome * 0.75)) / 8;

            Console.WriteLine($"Total income - {totalIncome:F2} BGN");
            Console.WriteLine($"Money for charity - {moneyForCharity:F2} BGN");
        }
    }
}
