using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static string CheckIfPalindrome(string input)           
        {                                                     
            while (true)                                        
            {                                                  
                int number = int.Parse(input);                  
                int rev = 0;   
				
                while (number > 0)                              
                {                                             
                    int lastNum = number % 10;                  
                    rev = rev * 10 + lastNum;                   
                    number /= 10;                               
                }  
				
                if (int.Parse(input) != rev)                    
                {                                               
                    return "false";                             
                }    
				
                else if (int.Parse(input) == rev)               
                {                                               
                    return "true";                              
                }                                             
            }                                                   
        }  
		
        static void Main(string[] args)                         
        {                                                       
            string input = Console.ReadLine();   
			
            while (input != "END")                              
            {                                                   
                Console.WriteLine(CheckIfPalindrome(input));    
                input = Console.ReadLine();                     
            }
        }
    }
}
