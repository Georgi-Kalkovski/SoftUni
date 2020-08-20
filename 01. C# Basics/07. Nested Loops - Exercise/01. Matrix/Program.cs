using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            for (int firstRowFirstNumber = a; firstRowFirstNumber <= b; firstRowFirstNumber++)
            {
                for (int firstRowSecondNumber = a; firstRowSecondNumber <= b; firstRowSecondNumber++)
                {
                    for (int secondRowFirstNumber = c; secondRowFirstNumber <= d; secondRowFirstNumber++)
                    {
                        for (int secondRowSecondNumber = c; secondRowSecondNumber <= d; secondRowSecondNumber++)
                        {
                            if (((firstRowFirstNumber + secondRowSecondNumber) == (firstRowSecondNumber + secondRowFirstNumber) && (firstRowFirstNumber != firstRowSecondNumber) && (secondRowFirstNumber != secondRowSecondNumber)))
                            {
                                Console.WriteLine($"{firstRowFirstNumber}{firstRowSecondNumber}");
                                Console.WriteLine($"{secondRowFirstNumber}{secondRowSecondNumber}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }

        }
    }
}
