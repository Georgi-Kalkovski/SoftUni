using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int numFromOneToNumber = 0;

            for (int rows = 1; rows <= number; rows++)
            {

                for (int cols = 1; cols <= rows; cols++)
                {

                    if (numFromOneToNumber >= number)
                    {
                        return;
                    }
					
                    numFromOneToNumber++;
                    Console.Write($"{numFromOneToNumber} ");
                }
				
                Console.WriteLine();
            }
        }
    }
}
