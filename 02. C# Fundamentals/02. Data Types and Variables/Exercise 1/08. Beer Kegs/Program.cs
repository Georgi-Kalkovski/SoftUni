using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfKegs = int.Parse(Console.ReadLine());        
            double maxVolume = double.MinValue;                      
            string biggestKeg = string.Empty;                        

            for (int i = 1; i <= numberOfKegs; i++)                  
            {                                                     
                string nameOfKeg = Console.ReadLine();               
                double radius = double.Parse(Console.ReadLine());    
                int height = int.Parse(Console.ReadLine());          

                double volume = Math.PI * (radius * radius) * height;

                if (volume > maxVolume)                              
                {                                                    
                    maxVolume = volume;                              
                    biggestKeg = nameOfKeg;                          
                }                                                    
            }    
			
            Console.WriteLine(biggestKeg);                           
        }
    }
}
