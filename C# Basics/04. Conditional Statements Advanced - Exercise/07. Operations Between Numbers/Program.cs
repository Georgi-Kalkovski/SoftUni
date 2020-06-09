using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            double numberOne = double.Parse(Console.ReadLine());
            double numberTwo = double.Parse(Console.ReadLine());
            string operations = Console.ReadLine();

            double result = 0;

            if (operations == "+") result = numberOne + numberTwo;
            else if (operations == "-") result = numberOne - numberTwo;
            else if (operations == "*") result = numberOne * numberTwo;
            else if (operations == "/") result = numberOne / numberTwo;
            else if (operations == "%") result = numberOne % numberTwo;

            if (operations == "+" || operations == "-" || operations == "*")
            {

                if (result % 2 == 0)
                    Console.WriteLine($"{numberOne} {operations} {numberTwo} = {result} - even");

                else
                    Console.WriteLine($"{numberOne} {operations} {numberTwo} = {result} - odd");
            }

            else if (operations == "/")
            {

                if (numberOne == 0 || numberTwo == 0)
                    Console.WriteLine($"Cannot divide {numberOne} by zero");

                else
                    Console.WriteLine($"{numberOne} {operations} {numberTwo} = {result:F2}");
            }

            else if (operations == "%")
            {

                if (numberOne == 0 || numberTwo == 0)
                    Console.WriteLine($"Cannot divide {numberOne} by zero");

                else
                    Console.WriteLine($"{numberOne} {operations} {numberTwo} = {result}");
            }
        }
    }
}
