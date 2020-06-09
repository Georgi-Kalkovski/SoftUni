using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Odd_or_Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());
            double oddSum = 0;
            double oddMinNum = double.MaxValue;
            double oddMaxNum = double.MinValue;
            double evenSum = 0;
            double evenMinNum = double.MaxValue;
            double evenMaxNum = double.MinValue;

            for (int i = 1; i <= num; i++)
            {
                if (i % 2 != 0)
                {
                    double oddNum = double.Parse(Console.ReadLine());
                    oddSum += oddNum;

                    if (oddNum < oddMinNum)
                    {
                        oddMinNum = oddNum;
                    }

                    if (oddNum > oddMaxNum)
                    {
                        oddMaxNum = oddNum;
                    }
                }

                else if (i % 2 == 0)
                {
                    double evenNum = double.Parse(Console.ReadLine());
                    evenSum += evenNum;

                    if (evenNum < evenMinNum)
                    {
                        evenMinNum = evenNum;
                    }

                    if (evenNum > evenMaxNum)
                    {
                        evenMaxNum = evenNum;
                    }
                }
            }

            if (num == 0)
            {
                Console.WriteLine($"OddSum={oddSum:F2},");
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
                Console.WriteLine($"EvenSum={evenSum:F2},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
                return;
            }

            else if (num == 1)
            {
                Console.WriteLine($"OddSum={oddSum:F2},");
                Console.WriteLine($"OddMin={oddMinNum:F2},");
                Console.WriteLine($"OddMax={oddMaxNum:F2},");
                Console.WriteLine($"EvenSum={evenSum:F2},");
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
                return;
            }
			
            Console.WriteLine($"OddSum={oddSum:F2},");
            Console.WriteLine($"OddMin={oddMinNum:F2},");
            Console.WriteLine($"OddMax={oddMaxNum:F2},");
            Console.WriteLine($"EvenSum={evenSum:F2},");
            Console.WriteLine($"EvenMin={evenMinNum:F2},");
            Console.WriteLine($"EvenMax={evenMaxNum:F2}");
        }
    }
}
