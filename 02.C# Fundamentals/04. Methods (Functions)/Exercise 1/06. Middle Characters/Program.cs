using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static string MiddleChars(string word, int i, int j)      
        {                                                         
            if (word.Length % 2 != 0)                             
            {                                                     
                while (i != j)                                    
                {                                                 
                    i++;                                          
                    j--;                                          
                }  
				
                return word[i].ToString();                        
            }      
			
            else                                                  
            {                                                     
                string result = string.Empty;                     

                while (i - j != 1)                                
                {                                                 
                    i++;                                          
                    j--;                                          
                }   
				
                result = word[j].ToString() + word[i].ToString(); 
                return result;                                    
            }                                                     
        }   
		
        static void Main(string[] args)                           
        {                                                         
            string word = Console.ReadLine();                     
            int i = 0;                                            
            int j = word.Length-1;                                
            Console.WriteLine(MiddleChars(word, i, j));           
        }
    }
}
