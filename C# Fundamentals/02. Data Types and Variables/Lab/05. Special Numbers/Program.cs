using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());                       
          
            for (int i = 1; i <= num; i++)                                 
            {                                                              
                int sum = 0;                                               
                string isTrue = "False";                                   

                if (i >= 10)                                               
                {                                                          
                    int lastDigit = i % 10;                                
                    sum = i / 10;                                          
                    sum += lastDigit;                                      
                }                                                          
               
                if (i == 5 || i == 7 || sum == 5 || sum == 7 || sum == 11) 
                {                                                         
                    isTrue = "True";                                       
                }      
				
                Console.WriteLine($"{i} -> {isTrue}");                     
            }
        }
    }
}
