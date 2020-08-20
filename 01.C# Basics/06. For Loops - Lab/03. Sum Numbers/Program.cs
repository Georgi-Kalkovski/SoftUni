using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int sum = 0;
			
            for (int i = 1; i <= number; i++)
            {
                int addNum = int.Parse(Console.ReadLine());
                sum += addNum;
            }
			
            Console.WriteLine(sum);

        }
    }
}
