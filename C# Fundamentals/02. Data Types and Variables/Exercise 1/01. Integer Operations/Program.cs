using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstNumber = int.Parse(Console.ReadLine());         
            int secondNumber = int.Parse(Console.ReadLine());        
            int thirdNumber = int.Parse(Console.ReadLine());         
            int fourthNumber = int.Parse(Console.ReadLine());        
            long result = ((firstNumber + secondNumber) / thirdNumber) * fourthNumber;
          
            Console.WriteLine(result);

        }
    }
}
