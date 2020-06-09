using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            int numbers = int.Parse(Console.ReadLine());
            int minNumber = int.MaxValue;

            for (int i = 0; i < numbers; i++)
            {
                int newNumber = int.Parse(Console.ReadLine());

                if (newNumber < minNumber)
                {
                    minNumber = newNumber;
                }
            }
			
            Console.WriteLine(minNumber);

        }
    }
}
