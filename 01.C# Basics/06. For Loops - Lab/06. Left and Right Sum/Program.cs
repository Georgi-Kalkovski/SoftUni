using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int numbers = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < numbers; i++)
            {
                int number = int.Parse(Console.ReadLine());
                leftSum += number;
            }

            for (int i = 0; i < numbers; i++)
            {
                int number = int.Parse(Console.ReadLine());
                rightSum += number;
            }

            int diff = Math.Abs(leftSum - rightSum);

            if (diff == 0)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }

            else if (diff != 0)
            {
                Console.WriteLine($"No, diff = {diff}");
            }
        }
    }
}
