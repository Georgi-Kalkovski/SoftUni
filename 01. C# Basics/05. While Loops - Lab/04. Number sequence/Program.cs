using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {

            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;

            string command = Console.ReadLine();

            while (command != "END")
            {
                int number = int.Parse(command);

                if (number < minNumber)
                {
                    minNumber = number;
                }

                if (number > maxNumber)
                {
                    maxNumber = number;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Max number: {maxNumber}");
            Console.WriteLine($"Min number: {minNumber}");
        }
    }
}
