using System;

namespace _01._Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());
            int daysTotal = int.Parse(Console.ReadLine());
            int sumOfCoins = 0;

            for (int i = 1; i <= daysTotal; i++)
            {
                if (i % 10 == 0)
                {
                    partySize -= 2;
                }
				
                if (i % 15 == 0)
                {
                    partySize += 5;
                }
				
                sumOfCoins += 50 - (partySize * 2);

                if (i % 3 == 0)
                {
                    sumOfCoins -= partySize * 3;
                }
				
                if (i % 5 == 0)
                {
                    sumOfCoins += partySize * 20;
					
                    if (i % 3 == 0)
                    {
                        sumOfCoins -= partySize * 2;
                    }
                }
            }
			
            int coinsPerCompanion = sumOfCoins / partySize;

            Console.WriteLine($"{partySize} companions received {coinsPerCompanion} coins each.");
        }
    }
}
