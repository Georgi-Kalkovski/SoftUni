using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {

            var number = int.Parse(Console.ReadLine());
            var letter  = int.Parse(Console.ReadLine());

            for (int x1 = 1; x1 <= number; x1++)
            {
                for (int x2 = 1; x2 < number; x2++)
                {
                    for (int x3 = 0; x3 < letter; x3++)
                    {
                        for (int x4 = 0; x4 < letter; x4++)
                        {
                            for (int x5 = Math.Max(x1,x2) +1; x5 <= number; x5++)
                            {
                                Console.Write($"{x1}{x2}{(char)(97+x3)}{(char)(97 + x4)}{x5} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
