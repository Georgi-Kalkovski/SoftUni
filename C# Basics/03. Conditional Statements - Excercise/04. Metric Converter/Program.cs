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
            // dobavqme na konzolata chislo
            string firstMeasure = Console.ReadLine();
            // vuvejdame na konzolata merna edinicia "mm", "cm" ili "m", v koqto shte e chislot
            string secondMeasure = Console.ReadLine();
            // vuvejdame na konzolata merna edinicia "mm", "cm" ili "m", na koqto iskame chisloto ni da bude prevurnata

            if (firstMeasure == "mm")
            // ako purvata edinica e "mm"
            {
                if (secondMeasure == "cm")
                // ako vtorata edinica e "cm"
                {
                    number /= 10;
                    // chisloto se deli na 10
                }
                else if (secondMeasure == "m")
                // ako vtorata edinica e "m"
                {
                    number /= 1000;
                    // chisloto se deli na 1000
                }
            }

            if (firstMeasure == "cm")
            // ako purvata edinica e "cm"
            {
                if (secondMeasure == "mm")
                // ako vtorata edinica e "mm"
                {
                    number *= 10;
                    // chisloto se umnojava po 10
                }
                else if (secondMeasure == "m")
                // ako vtorata edinica e "mm"
                {
                    number /= 100;
                    // chisloto se deli na 100
                }
            }

            if (firstMeasure == "m")
            // ako purvata edinica e "m"
            {
                if (secondMeasure == "cm")
                // ako vtorata edinica e "cm"
                {
                    number *= 100;
                    // chisloto se umnojava po 100
                }
                else if (secondMeasure == "mm")
                // ako vtorata edinica e "mm"
                {
                    number *= 1000;
                    // chisloto se umnojava po 1000
                }
            }
            Console.WriteLine($"{number:F3}");
            // vadim na konzolata chisloto do 3tata cifra sled desetchnata zapetaq
        }
    }
}
