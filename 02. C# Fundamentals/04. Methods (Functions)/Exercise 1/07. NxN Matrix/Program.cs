using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static int NxNResult(int number)                
        {                                              
            for (int col = 0; col < number; col++)      
            {                                         
                for (int row = 0; row < number; row++)  
                {                                       
                    Console.Write(number + " ");        
                }   
				
                Console.WriteLine();                    
            }     
			
            return number;                              
        }         
		
        static void Main(string[] args)                 
        {                                              
            int number = int.Parse(Console.ReadLine()); 
            NxNResult(number);                          
        }
    }
}
