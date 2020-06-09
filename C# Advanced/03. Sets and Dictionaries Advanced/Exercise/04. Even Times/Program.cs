using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersInput = int.Parse(Console.ReadLine());

            Dictionary<int,int> numbers = new Dictionary<int,int>();
            
            for (int i = 0; i < numbersInput; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(currentNumber))
                {
                    numbers.Add(currentNumber, +1);
                }

                else
                {
                    numbers[currentNumber] += 1;
                }
            }

            foreach (var number in numbers)
            {

                if (number.Value % 2 == 0)
                {
                    Console.WriteLine(number.Key);
                    break;
                }
            }
            
        }
    }
}
