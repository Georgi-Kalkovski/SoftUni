using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] inputArray = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int[] leftFold = new int[inputArray.Length / 4];
        int[] rightFold = new int[inputArray.Length / 4];
        int[] resultArray = new int[inputArray.Length / 2];

        for (int i = 0; i < (inputArray.Length / 4); i++)
        {
            leftFold[i] = inputArray[(inputArray.Length / 4) - 1 - i];
            rightFold[i] = inputArray[inputArray.Length - 1 - i];
        }

        for (int i = 0; i < (inputArray.Length / 4); i++)
        {
            resultArray[i] = leftFold[i] + inputArray[inputArray.Length / 4 + i];
            resultArray[inputArray.Length / 4 + i] = rightFold[i] + inputArray[inputArray.Length / 2 + i];
        }

        Console.WriteLine(string.Join(" ", resultArray));
    }
}