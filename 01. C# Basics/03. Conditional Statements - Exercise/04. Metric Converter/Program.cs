using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {

            double number = double.Parse(Console.ReadLine());
            string firstMeasure = Console.ReadLine();
            string secondMeasure = Console.ReadLine();
            
            if (firstMeasure == "mm")
            {
                if (secondMeasure == "cm")
                {
                    number /= 10;
                }
                else if (secondMeasure == "m")
                {
                    number /= 1000;
                }
            }

            if (firstMeasure == "cm")
            {
                if (secondMeasure == "mm")
                {
                    number *= 10;
                }
                else if (secondMeasure == "m")
                {
                    number /= 100;
                }
            }

            if (firstMeasure == "m")
            {
                if (secondMeasure == "cm")
                {
                    number *= 100;
                }
                else if (secondMeasure == "mm")
                {
                    number *= 1000;
                }
            }
            Console.WriteLine($"{number:F3}");
        }
    }
}
