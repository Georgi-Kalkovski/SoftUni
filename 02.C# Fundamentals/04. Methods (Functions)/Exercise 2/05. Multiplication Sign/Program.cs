using System;

namespace _05._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
                return;
            }
			
            int counterOfNegatives = 0;

            if (num1 < 0)
            {
                counterOfNegatives++;
            }
			
            if (num2 < 0)
            {
                counterOfNegatives++;
            }
			
            if (num3 < 0)
            {
                counterOfNegatives++;
            }
			
            if (counterOfNegatives % 2 != 0)
            {
                Console.WriteLine("negative");
                return;
            }
			
            else
            {
                Console.WriteLine("positive");
            }
        }
    }
}
