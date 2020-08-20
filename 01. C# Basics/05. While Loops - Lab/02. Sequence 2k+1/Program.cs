using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            int n = 1;

            while (n <= number)
            {
                Console.WriteLine(n);

                n = n * 2 + 1;
            }
        }
    }
}
