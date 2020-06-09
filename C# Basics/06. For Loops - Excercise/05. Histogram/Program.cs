using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {

            int numbersTotal = int.Parse(Console.ReadLine());
            double numbers1 = 0;
            double numbers2 = 0;
            double numbers3 = 0;
            double numbers4 = 0;
            double numbers5 = 0;

            for (int i = 0; i < numbersTotal; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 200)
                    numbers1 ++;
				
                if (number >= 200 && number < 400)
                    numbers2 ++;
				
                if (number >= 400 && number < 600)
                    numbers3++;
				
                if (number >= 600 && number < 800)
                    numbers4++;
				
                if (number >= 800)
                    numbers5++;
            }

            double percent1 = (numbers1 / numbersTotal) * 100;
            double percent2 = (numbers2 / numbersTotal) * 100;
            double percent3 = (numbers3 / numbersTotal) * 100;
            double percent4 = (numbers4 / numbersTotal) * 100;
            double percent5 = (numbers5 / numbersTotal) * 100;

            Console.WriteLine($"{percent1:F2}%");
            Console.WriteLine($"{percent2:F2}%");
            Console.WriteLine($"{percent3:F2}%");
            Console.WriteLine($"{percent4:F2}%");
            Console.WriteLine($"{percent5:F2}%");

        }
    }
}
