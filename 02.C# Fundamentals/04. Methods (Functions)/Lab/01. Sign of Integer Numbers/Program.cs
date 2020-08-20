using System;

namespace _01._Sign_of_Integer_Numbers
{
    class Program
    {
        static void PrintResult(int n, string plusMinusOrZero)           
        {                                                               
            Console.WriteLine($"The number {n} is {plusMinusOrZero}.");  
        }                                                                

        static void Main()                                               
        {                                                                
            int n = int.Parse(Console.ReadLine());                       

            string plusMinusOrZero = string.Empty;                       

            if (n > 0)                                                   
            {                                                            
                plusMinusOrZero = "positive";                            
            }    
			
            else if (n < 0)                                              
            {                                                            
                plusMinusOrZero = "negative";                            
            }  
			
            else if (n == 0)                                             
            {                                                            
                plusMinusOrZero = "zero";                                
            }  
			
            PrintResult(n, plusMinusOrZero);                             
        }
    }
}
