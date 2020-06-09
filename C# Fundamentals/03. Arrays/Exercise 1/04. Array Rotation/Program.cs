using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()                       
                .Split()                                             
                .Select(int.Parse)                                   
                .ToArray();                                          

            int numOfRotations = int.Parse(Console.ReadLine());      

            for (int i = 0; i < numOfRotations % numbers.Length; i++)
            {                                                        
                int firstNumber = numbers[0];                  

                for (int j = 0; j < numbers.Length - 1; j++)         
                { 
					numbers[j] = numbers[j + 1];                     
                }              
				
                numbers[numbers.Length - 1] = firstNumber;          
            }         
			
            Console.WriteLine(string.Join(" ", numbers));            
        }
    }
}
 