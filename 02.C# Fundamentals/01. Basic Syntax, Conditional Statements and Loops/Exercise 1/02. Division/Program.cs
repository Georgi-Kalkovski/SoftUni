using System;

namespace _02._Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());                 
            int division = 0;                                           

            while (true)                                                
            {
                if (number % 10 == 0)                                   
                {
                    division += 10;                                     
                    break;                                              
                }
				
                else if (number % 7 == 0)                               
                {
                    division += 7;                                      
                    break;                                              
                }
				
                else if (number % 6 == 0)                               
                {
                    division += 6;                                      
                    break;                                              
                }
				
                else if (number % 3 == 0)                               
                {
                    division += 3;                                      
                    break;                                              
                }
				
                else if (number % 2 == 0)                               
                {
                    division += 2;                                      
                    break;                                              
                }
				
                else                                                    
                {
                    Console.WriteLine($"Not divisible");                
                    return;                                             
                }
            }
			
            Console.WriteLine($"The number is divisible by {division}");  
        }
    }
}
