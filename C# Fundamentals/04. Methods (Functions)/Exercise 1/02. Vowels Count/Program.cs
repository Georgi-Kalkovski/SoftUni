using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static int VowelsCheck(string word)             
        {                                              
            int vowelsCounter = 0;         
			
            for (int i = 0; i < word.Length; i++)       
            {                                           
                if (word[i] == 'a' || word[i] == 'o' || 
                    word[i] == 'e' || word[i] == 'i' || 
                    word[i] == 'u' || word[i] == 'A' || 
                    word[i] == 'O' || word[i] == 'E' || 
                    word[i] == 'I' || word[i] == 'U')   
                {                                       
                    vowelsCounter++;                    
                }                                       
            }         
			
            return vowelsCounter;                       
        }     
		
        static void Main(string[] args)                 
        {                                               
            string word = Console.ReadLine();           

            Console.WriteLine(VowelsCheck(word));       
        }
    }
}
