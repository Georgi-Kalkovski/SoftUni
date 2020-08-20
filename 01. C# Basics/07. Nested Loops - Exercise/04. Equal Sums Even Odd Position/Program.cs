using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {

            int lowerNumber = int.Parse(Console.ReadLine());
            int higherNumber = int.Parse(Console.ReadLine());

            for (int i = lowerNumber; i <= higherNumber; i++)
            {
                string currentNum = i.ToString();
                int oddSum = 0;
                int evenSum = 0;

                for (int j = 0; j < currentNum.Length; j++)
                {
                    int currentDigit = int.Parse(currentNum[j].ToString());

                    if (j % 2 == 0)
                    {
                        evenSum += currentDigit;
                    }

                    else if (j % 2 != 0)
                    {
                        oddSum += currentDigit;
                    }
                }

                if (oddSum == evenSum)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
