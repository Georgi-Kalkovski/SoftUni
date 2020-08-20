using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()       
                .Split()                           
                .Select(int.Parse)                 
                .ToArray();                        

            int len = 1;                           
            int bestStart = 0;                     
            int bestLength = 1;                    

            for (int i = 1; i < input.Length; i++) 
            {                                    
                if (input[i] == input[i - 1])      
                {                                 
                    len++;                         

                    if (len > bestLength)          
                    {                              
                        bestLength = len;          
                        bestStart = input[i];      
                    }                              
                }                                  

                else                               
                {                                  
                    len = 1;                       
                }                                  
            }                                      

            for (int i = 0; i < bestLength; i++)   
            {                                      
                Console.Write(bestStart + " ");    
            }
        }
    }
}
