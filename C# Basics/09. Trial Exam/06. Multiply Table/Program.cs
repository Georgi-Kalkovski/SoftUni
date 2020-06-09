using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Multiply_Table
{
    class Program
    {
        static void Main(string[] args)
        {

            string number = Console.ReadLine();

            for (char x1 = '1'; x1 <= number[2]; x1++)
            {
                for (char x2 = '1'; x2 <= number[1]; x2++)
                {
                    for (char x3 = '1'; x3 <= number[0]; x3++)
                    {
                        Console.WriteLine($"{x1} * {x2} * {x3} = {((char)(x3-48) * (char)(x2 - 48) * (char)(x1 - 48))};");
                    }
                }
            }
        }
    }
}
