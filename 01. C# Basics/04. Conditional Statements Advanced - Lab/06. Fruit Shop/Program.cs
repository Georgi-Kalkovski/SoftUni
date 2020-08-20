using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (fruit == "banana") Console.WriteLine($"{(amount * 2.50):F2}");
                else if (fruit == "apple") Console.WriteLine($"{(amount * 1.20):F2}");
                else if (fruit == "orange") Console.WriteLine($"{(amount * 0.85):F2}");
                else if (fruit == "grapefruit") Console.WriteLine($"{(amount * 1.45):F2}");
                else if (fruit == "kiwi") Console.WriteLine($"{(amount * 2.70):F2}");
                else if (fruit == "pineapple") Console.WriteLine($"{(amount * 5.50):F2}");
                else if (fruit == "grapes") Console.WriteLine($"{(amount * 3.85):F2}");
                else Console.WriteLine("error");
            }

            else if (day == "Saturday" || day == "Sunday")
            {
                if (fruit == "banana") Console.WriteLine($"{(amount * 2.70):F2}");
                else if (fruit == "apple") Console.WriteLine($"{(amount * 1.25):F2}");
                else if (fruit == "orange") Console.WriteLine($"{(amount * 0.90):F2}");
                else if (fruit == "grapefruit") Console.WriteLine($"{(amount * 1.60):F2}");
                else if (fruit == "kiwi") Console.WriteLine($"{(amount * 3.00):F2}");
                else if (fruit == "pineapple") Console.WriteLine($"{(amount * 5.60):F2}");
                else if (fruit == "grapes") Console.WriteLine($"{(amount * 4.20):F2}");
                else Console.WriteLine("error");
            }

            else Console.WriteLine("error");
        }
    }
}
