using System;

namespace _07._Repeat_String
{
    class Program
    {
        static string RepeatString(string input, int repeatCount) 
        {                                                         
            string result = string.Empty;                         

            for (int i = 0; i < repeatCount; i++)                 
            {                                                     
                result += input;                                  
            }            
			
            return result;                                        
        }        
		
        static void Main(string[] args)                           
        {                                                         
            string input = Console.ReadLine();                    
            int repeatCount = int.Parse(Console.ReadLine());     
            Console.WriteLine(RepeatString(input, repeatCount));  
        }
    }
}
