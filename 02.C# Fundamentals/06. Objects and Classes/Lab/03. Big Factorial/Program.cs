using System;
using System.Numerics;

namespace _03._Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            BigInteger factorialSum = 1;               

            for (int i = number; i >= 1; i--)          
            {                                        
                factorialSum = factorialSum * i;       
            }                                          

            Console.WriteLine(factorialSum);           
        }
    }
}
