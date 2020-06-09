using System;

namespace _03._Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double numOne = double.Parse(Console.ReadLine()); 
            double numTwo = double.Parse(Console.ReadLine()); 

            if (Math.Abs(numOne - numTwo) <= 0.000001)        
                Console.WriteLine(true);                      

            else                                              
                Console.WriteLine(false);                     
        }
    }
}