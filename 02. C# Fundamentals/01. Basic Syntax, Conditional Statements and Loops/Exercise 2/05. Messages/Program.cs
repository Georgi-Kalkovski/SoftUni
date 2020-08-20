using System;

namespace _05._Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());       
			
            for (int i = 0; i < n; i++)                             
            {
                string input = Console.ReadLine();                  
                int offset = 0;                                     
                char ch = ' ';                                      
                int digitLength = input.Length;                     
                int mainDigit = input[0] - '0';                     

                if (mainDigit == 0)                                 
                {
                    Console.Write(ch);                              
                    continue;                                       
                }

                if (mainDigit == 8 || mainDigit == 9)               
                {
                    offset = (mainDigit - 2) * 3;                   
                    offset++;                                       
                }

                if (mainDigit != 8 && mainDigit != 9)               
                {
                    offset = (mainDigit - 2) * 3;                   
                }
				
                int letterIndex = (offset + digitLength - 1) + 'a'; 
                ch = (char)letterIndex;                             
                Console.Write(ch);                                  
            }
        }
    }
}
