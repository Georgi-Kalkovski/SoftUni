using System;
using System.Linq;
namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()       
                .Split()                             
                .Select(int.Parse)                   
                .ToArray();                          

            int leftSum = 0;                         
            int rightSum = 0;                        

            for (int i = 0; i < numbers.Length; i++) 
            {                                        
                rightSum += numbers[i];              
            }                                        

            for (int i = 0; i < numbers.Length; i++) 
            {                                        
                rightSum -= numbers[i];              

                if (rightSum == leftSum)             
                {                                    
                    Console.WriteLine(i);            
                    return;                          
                }                                    

                leftSum += numbers[i];               
            }                                        

            Console.WriteLine("no");                 
        }
    }
}
