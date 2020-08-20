using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine()
                .Split();

            string leftSide = line[0];
            string rightSide = line[1];

            int totalSum = 0;

            if (leftSide.Length == rightSide.Length)
            {
                for (int i = 0; i < leftSide.Length; i++)
                {
                    totalSum += leftSide[i] * rightSide[i];
                }
            }
			
            else if (leftSide.Length > rightSide.Length)
            {
                for (int i = 0; i < rightSide.Length; i++)
                {
                    totalSum += leftSide[i] * rightSide[i];
                }
				
                for (int i = rightSide.Length; i < leftSide.Length; i++)
                {
                    totalSum += leftSide[i];
                }
            }
			
            else if (rightSide.Length > leftSide.Length)
            {
                for (int i = 0; i < leftSide.Length; i++)
                {
                    totalSum += leftSide[i] * rightSide[i];
                }
				
                for (int i = leftSide.Length; i < rightSide.Length; i++)
                {
                    totalSum += rightSide[i];
                }
            }
			
            Console.WriteLine(totalSum);
        }
    }
}
