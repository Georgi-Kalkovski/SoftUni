using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static string FromFirstToSecondChar(char firstChar, char secondChar)    
        {                                                                       
            string currentChar = string.Empty;     
			
            if (firstChar < secondChar)                                         
            {                                                                   
                for (int i = (char)firstChar + 1; i < (char)secondChar; i++)    
                {                                                               
                    currentChar += (char)i + " ";                               
                }                                                               
            }    
			
            else                                                                
            {                                                                   
                for (int i = (char)secondChar + 1; i < (char)firstChar; i++)    
                {                                                               
                    currentChar += (char)i + " ";                               
                }                                                               
            }        
			
            return currentChar;                                                 
        }          
		
        static void Main(string[] args)                                         
        {                                                                       
            char firstChar = char.Parse(Console.ReadLine());                    
            char secondChar = char.Parse(Console.ReadLine());                   

            Console.Write(FromFirstToSecondChar(firstChar, secondChar));        
        }
    }
}
