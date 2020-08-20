using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxNum = int.MinValue;

            for (int i = 0; i < num; i++)
            {
                int newNum = int.Parse(Console.ReadLine());

                if (maxNum < newNum && newNum != num)
                {
                    maxNum = newNum;
                }
                sum += newNum;
            }
			
            sum -= maxNum;

            if (sum == maxNum)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {sum}");
            }
			
            else if (sum != maxNum)
            {
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {Math.Abs(sum-maxNum)}");
            }
        }
    }
}
