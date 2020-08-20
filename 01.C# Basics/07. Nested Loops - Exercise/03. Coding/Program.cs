using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Coding
{
    class Program
    {
        static void Main(string[] args)
        {

            string number = Console.ReadLine();

            for (int i = number.Length - 1; i >= 0; i--)
            {
                char currentDigit = number[i];

                if (currentDigit == '0')
                {
                    Console.WriteLine("ZERO");
                    continue;
                }
				
                int currentDigitToString = int.Parse(currentDigit.ToString());
                char finalChar = (char)(currentDigitToString + 33);

                for (int y = 0; y < currentDigitToString; y++)
                {
                    Console.Write(finalChar);
                }
                Console.WriteLine();
            }
        }
    }
}
