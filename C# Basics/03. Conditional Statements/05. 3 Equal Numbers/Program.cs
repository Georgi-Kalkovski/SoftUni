using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._3_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            double numOne = double.Parse(Console.ReadLine());
            double numTwo = double.Parse(Console.ReadLine());
            double numThree = double.Parse(Console.ReadLine());

            if (numOne == numTwo && numOne == numThree)
            {
                Console.WriteLine("yes");
            }

            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
