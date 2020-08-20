using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Divide_without_remainder
{
    class Program
    {
        static void Main(string[] args)
        {

            int numbersTotal = int.Parse(Console.ReadLine());

            double del2 = 0;
            double del3 = 0;
            double del4 = 0;

            for (int i = 0; i < numbersTotal; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                    del2 ++;
				
                if (number % 3 == 0)
                    del3++;
				
                if (number % 4 == 0)
                    del4++;
            }

            double percent1 = (del2 / numbersTotal) * 100;
            double percent2 = (del3 / numbersTotal) * 100;
            double percent3 = (del4 / numbersTotal) * 100;

            Console.WriteLine($"{percent1:F2}%");
            Console.WriteLine($"{percent2:F2}%");
            Console.WriteLine($"{percent3:F2}%");
        }
    }
}
