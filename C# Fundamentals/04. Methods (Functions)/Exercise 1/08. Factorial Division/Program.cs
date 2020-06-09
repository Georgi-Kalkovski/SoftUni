using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static double FindingFactoriels(double firstNum, double secondNum)     
        {                                                                     
            double firstNumSaved = firstNum;  
			
            for (int i = 1; i < firstNumSaved; i++)                            
            {                                                                  
                firstNum *= i;                                                 
            }                                                                 

            double secondNumSaved = secondNum;  
			
            for (int i = 1; i < secondNumSaved; i++)                           
            {                                                                 
                secondNum *= i;                                                
            }                                                                  

            double result = firstNum / secondNum;                              
            return result;                                                     
        }  
		
        static void Main(string[] args)                                        
        {                                                                      
            double firstNum = double.Parse(Console.ReadLine());                
            double secondNum = double.Parse(Console.ReadLine());               

            Console.WriteLine($"{FindingFactoriels(firstNum, secondNum):F2}"); 
        }
    }
}
