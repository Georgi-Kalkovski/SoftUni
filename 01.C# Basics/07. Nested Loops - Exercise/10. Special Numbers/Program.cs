using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            for (int x1 = 1; x1 <= 9; x1++)
            {
                for (int x2 = 1; x2 <= 9; x2++)
                {
                    for (int x3 = 1; x3 <= 9; x3++)
                    {
                        for (int x4 = 1; x4 <= 9; x4++)
                        {
                            int sum = Convert.ToInt32($"{x1}{x2}{x3}{x4}");

                            if (number % x1 == 0 && number % x2 == 0 && number % x3 == 0 && number % x4 == 0)
                            {
                                Console.Write(sum + " ");
                            }
                        }
                    }
                }
            }
        }
    }
}
