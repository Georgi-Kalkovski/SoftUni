using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Even_Powers_of_2
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int current = 1;

            for (int i = 0; i <= number; i += 2)
            {
                Console.WriteLine(current);
                current = current * 4;
            }

        }
    }
}
