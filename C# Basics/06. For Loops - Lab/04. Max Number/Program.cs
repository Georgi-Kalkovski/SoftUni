using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            int numbers = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;

            for (int i = 0; i < numbers; i++)
            {
                int newNumber = int.Parse(Console.ReadLine());

                if (newNumber > maxNumber)
                {
                    maxNumber = newNumber;
                }
            }
            Console.WriteLine(maxNumber);

        }
    }
}
