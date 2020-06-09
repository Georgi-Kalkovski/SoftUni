using System;

namespace _10._Top_Number
{
    class Program
    {
        static string FindTopNumbers(int number)           
        {                                               
            for (int i = 0; i < number; i++)               
            {                                            
                int sum = 0;                               
                bool oddDigit = false;                     
                int currentNum = i;                        

                while (currentNum > 0)                     
                {                                         
                    int right = currentNum % 10;           
                    sum += right;                          

                    if (right % 2 != 0) oddDigit = true;   
                    currentNum /= 10;                      
                }                                          

                if (sum % 8 == 0 && oddDigit == true)      
                {                                          
                    Console.WriteLine(i);                  
                }                                          
            }     
			
            return "";                                     
        }     
		
        static void Main(string[] args)                    
        {                                                  
            int number = int.Parse(Console.ReadLine());  
            FindTopNumbers(number);                        
        }
    }
}
