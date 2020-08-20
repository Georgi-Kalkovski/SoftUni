using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int lastSum = 0;
            int diff = 0;

            for (int i = 0; i < n; i++)
            {
                int numOne = int.Parse(Console.ReadLine());
                int numTwo = int.Parse(Console.ReadLine());
                int sumNew = numOne + numTwo;

                if (i > 0)
                {
                    diff = Math.Abs(lastSum - sumNew);
                }
                lastSum = sumNew;
            }

            if (diff == 0)
            {
                Console.WriteLine($"Yes, value={lastSum}");
            }

            else
            {
                Console.WriteLine($"No, maxdiff={diff}");
            }
        }
    }
}
