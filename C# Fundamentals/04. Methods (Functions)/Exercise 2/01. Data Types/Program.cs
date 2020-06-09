using System;

namespace _01._Data_Types
{
    class Program
    {
        static int IfInt(string secondInput)
        {
            return int.Parse(secondInput) * 2;
        }

        static void IfReal(string secondInput)
        {
            double stringToDouble = double.Parse(secondInput);
            Console.WriteLine($"{(stringToDouble * 1.5):F2}");
        }

        static string IfString(string secondInput)
        {
            return $"{secondInput:F2}";
        }

        static void PrintFinalResult(string firstInput, string secondInput)
        {
            if (firstInput == "int") Console.WriteLine(IfInt(secondInput));
            if (firstInput == "real") IfReal(secondInput);
            if (firstInput == "string") Console.WriteLine(IfString($"${secondInput}$"));
        }

        static void Main(string[] args)
        {
            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();

            PrintFinalResult(firstInput,secondInput);
        }
    }
}
