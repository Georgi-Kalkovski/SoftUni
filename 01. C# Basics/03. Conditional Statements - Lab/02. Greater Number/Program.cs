using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Greater_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            double numOne = double.Parse(Console.ReadLine());
            double numTwo = double.Parse(Console.ReadLine());

            if (numOne > numTwo)
            {
                Console.WriteLine(numOne);
            }

            else
                Console.WriteLine(numTwo);

        }
    }
}
