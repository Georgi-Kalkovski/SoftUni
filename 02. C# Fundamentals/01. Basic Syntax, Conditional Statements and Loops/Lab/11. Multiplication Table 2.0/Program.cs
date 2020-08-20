using System;

namespace _11._Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());                 
            int secondNum = int.Parse(Console.ReadLine());                

            if (secondNum >= 10)                                          
            {
                int sum = firstNum * secondNum;                           
                Console.WriteLine($"{firstNum} X {secondNum} = {sum}");   
            }

            for (int i = secondNum; i <= 10; i++)                         
            {
                int sum = firstNum * i;                                   
                Console.WriteLine($"{firstNum} X {i} = {sum}");           
            }
        }
    }
}
