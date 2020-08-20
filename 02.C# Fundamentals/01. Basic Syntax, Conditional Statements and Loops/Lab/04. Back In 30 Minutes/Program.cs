using System;

namespace _04._Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());          
            int minutes = int.Parse(Console.ReadLine());      
			
            minutes += 30;                                      
			
            if (minutes >= 60)                                  
            {
                minutes -= 60;                                  
                hours++;                                        
            }                                                   
			
            if (hours >= 24)                                    
            {                                                   
                hours -= 24;                                    
            }                                                   
			
            if (minutes < 10)                                   
            {                                                   
                Console.WriteLine($"{hours}:0{minutes}");       
            }                                                  
			
            else                                                
            {                                                   
                Console.WriteLine($"{hours}:{minutes}");        
            }
        }
    }
}
