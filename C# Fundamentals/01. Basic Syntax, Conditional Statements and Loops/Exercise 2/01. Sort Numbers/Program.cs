using System;

namespace _01._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            for (int i = 1000; i > -1000; i--)
            {
                if (i == firstNumber)
                {
                    Console.WriteLine(firstNumber);
                }
				
                if (i == secondNumber)
                {
                    Console.WriteLine(secondNumber);
                }
				
                if (i == thirdNumber)
                {
                    Console.WriteLine(thirdNumber);
                }
            }
        }
    }
}
