using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());
            int even = 0;
            int odd = 0;
			
            for (int i = 0; i < num; i++)
            {
                int newNum = int.Parse(Console.ReadLine());
				
                if (i % 2 == 0)
                {
                    even += newNum;
                }
				
                else if (i % 2 != 0)
                {
                    odd += newNum;
                }
            }
			
            if (odd - even == 0)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {even}");
            }
			
            else if (odd - even != 0)
            {
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {Math.Abs(odd - even)}");
            }
        }
    }
}
