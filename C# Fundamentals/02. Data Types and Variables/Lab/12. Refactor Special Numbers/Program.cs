using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            int number = 0;
            bool isTrue = false;
			
            for (int i = 1; i <= num; i++)
{
                number = i;
				
                while (i > 0)
{
                    sum += i % 10;
                    i = i / 10;
                }
				
                isTrue = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{number} -> {isTrue}");
                sum = 0;
                i = number;
            }
        }
    }
}
