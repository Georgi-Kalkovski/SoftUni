using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Magic_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int magicNumber = int.Parse(Console.ReadLine());

            for (int firstNumber = 1; firstNumber <= 9; firstNumber++)
            {
                for (int secondNumber = 1; secondNumber <= 9; secondNumber++)
                {
                    for (int thirdNumber = 1; thirdNumber <= 9; thirdNumber++)
                    {
                        for (int fourthNumber = 1; fourthNumber <= 9; fourthNumber++)
                        {
                            for (int fifthNumber = 1; fifthNumber <= 9; fifthNumber++)
                            {
                                for (int sixthNumber = 1; sixthNumber <= 9; sixthNumber++)
                                {
                                    int product = firstNumber * secondNumber * thirdNumber * fourthNumber * fifthNumber * sixthNumber;
                                    
									if (product == magicNumber)
                                    {
                                        Console.Write($"{firstNumber}{secondNumber}{thirdNumber}{fourthNumber}{fifthNumber}{sixthNumber} ");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
