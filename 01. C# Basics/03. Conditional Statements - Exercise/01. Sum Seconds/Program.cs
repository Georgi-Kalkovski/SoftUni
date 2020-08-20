using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {

            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());

            int sum = numOne + numTwo + numThree;

            if (sum <= 59)
            {
                if (sum <= 9)
                {
                    Console.WriteLine($"0:0{sum}");
                }

                else
                {
                    Console.WriteLine($"0:{sum}");
                }
            }

            else if (sum >= 60 && sum <= 119)
            {
                if (sum - 60 <= 9)
                {
                    Console.WriteLine($"1:0{sum- 60}");
                }

                else
                {
                    Console.WriteLine($"1:{sum - 60}");
                }
            }

            else if (sum >= 120 && sum <= 179)
            {
                if (sum - 120 <= 9)
                {
                    Console.WriteLine($"2:0{sum - 120}");
                }

                else
                {
                    Console.WriteLine($"2:{sum - 120}");
                }
            }

        }
    }
}
