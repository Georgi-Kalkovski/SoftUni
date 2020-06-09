using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfLines = int.Parse(Console.ReadLine());  

            int tankCapacity = 255;                             
            int sumOfWater = 0;                                 

            for (int i = 0; i < numberOfLines; i++)             
            {                                                   
                int waterPlus = int.Parse(Console.ReadLine());  

                if (waterPlus > tankCapacity)                   
                {                                               
                    Console.WriteLine("Insufficient capacity!");
                    continue;                                   
                }
				
                else                                            
                {                                               
                    tankCapacity -= waterPlus;                  
                    sumOfWater += waterPlus;                    
                }                                               
            } 
			
            Console.WriteLine(sumOfWater);                      
        }
    }
}
