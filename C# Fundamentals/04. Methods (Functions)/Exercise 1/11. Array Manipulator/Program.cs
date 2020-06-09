using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Exchange(int[] mainArray, string[] inputToArray)
        {
            if (int.Parse(inputToArray[1]) - 1 > inputToArray.Length)
            {
                Console.WriteLine("Invalid index");
            }
			
            else
            {
                int numOfRotations = int.Parse(inputToArray[1]);
                int firstNum = 0;

                while (numOfRotations != -1)
                {
                    firstNum = mainArray[0];

                    for (int i = 0; i < mainArray.Length - 1; i++)
                    {
                        mainArray[i] = mainArray[i + 1];
                    }
					
                    mainArray[mainArray.Length - 1] = firstNum;
                    numOfRotations--;
                }
            }

        }

        static string MaxEvenOrOdd(int[] mainArray, string[] inputToArray)
        {
            int maxEvenOrOdd = int.MinValue;
            int index = 0;
            string result = string.Empty;

            if (inputToArray[1] == "even")
            {
                for (int i = 0; i < mainArray.Length; i++)
                {
                    if (maxEvenOrOdd < mainArray[i] && mainArray[i] % 2 == 0)
                    {
                        maxEvenOrOdd = mainArray[i];
                        index = i;
                    }
					
                    else continue;
                }
            }
			
            else if (inputToArray[1] == "odd")
            {
                for (int i = 0; i < mainArray.Length; i++)
                {
                    if (maxEvenOrOdd < mainArray[i] && mainArray[i] % 2 != 0)
                    {
                        maxEvenOrOdd = mainArray[i];
                        index = i;
                    }
					
                    else continue;
                }
            }
			
            else if (index > 0) result = index.ToString();
            else result = "No matches";
            return result;
        }

        static string MinEvenOrOdd(int[] mainArray, string[] inputToArray)
        {
            int minEvenOrOdd = int.MaxValue;
            int index = 0;
            string result = string.Empty;

            if (inputToArray[1] == "even")
            {
                for (int i = 0; i < mainArray.Length; i++)
                {
                    if (minEvenOrOdd > mainArray[i] && mainArray[i] % 2 == 0)
                    {
                        minEvenOrOdd = mainArray[i];
                        index = i;
                    }
					
                    else continue;
                }
            }

            else if (inputToArray[1] == "odd")
            {
                for (int i = 0; i < mainArray.Length; i++)
                {
                    if (minEvenOrOdd > mainArray[i] && mainArray[i] % 2 != 0)
                    {
                        minEvenOrOdd = mainArray[i];
                        index = i;
                    }
					
                    else continue;
                }
            }
			
            else if (index > 0) result = index.ToString();
            else result = "No matches";
            return result;
        }

        
        static void Main(string[] args)
        {
            int[] mainArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();
			
            while (input != "end")
            {
                string[] inputToArray = input.
                    Split().
                    ToArray();

                if (inputToArray[0] == "exchange") Exchange(mainArray, inputToArray);
                if (inputToArray[0] == "max") Console.WriteLine(MaxEvenOrOdd(mainArray, inputToArray));
                if (inputToArray[0] == "min") Console.WriteLine(MinEvenOrOdd(mainArray, inputToArray));

                input = Console.ReadLine();
            }
        }
    }
}
