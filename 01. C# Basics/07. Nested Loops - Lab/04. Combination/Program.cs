using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Combination
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            int combinations = 0;

            for (int x1 = 0; x1 <= number; x1++)
            {
                for (int x2 = 0; x2 <= number; x2++)
                {
                    for (int x3 = 0; x3 <= number; x3++)
                    {
                        for (int x4 = 0; x4 <= number; x4++)
                        {
                            for (int x5 = 0; x5 <= number; x5++)
                            {
                                if (x1 + x2 + x3 + x4 + x5 == number)
                                {
                                    combinations++;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(combinations);
        }
    }
}
