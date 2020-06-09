using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {

            int tournaments = int.Parse(Console.ReadLine());    
            int startingPoints = int.Parse(Console.ReadLine()); 
            int W = 2000;                                       
            int F = 1200;                                       
            int SF = 720;                                       
            int sumOfPoints = 0;                                
            double counterOfW = 0;                              

            for (int i = 0; i < tournaments; i++)  
            {                                      
                string input = Console.ReadLine(); 
                                                   
                if (input == "W")                  
                {                                  
                    sumOfPoints += W;              
                    counterOfW++;                  
                }                                  
                                                   
                else if (input == "F")             
                {                                  
                    sumOfPoints += F;              
                }                                  
                                                   
                else if (input == "SF")            
                {                                  
                    sumOfPoints += SF;             
                }
            }

            int totalPoints = startingPoints + sumOfPoints;          
            int averagePoints = sumOfPoints / tournaments;           
            double percentageOfW = (counterOfW / tournaments) * 100; 
                                                                     
            Console.WriteLine($"Final points: {totalPoints}");       
            Console.WriteLine($"Average points: {averagePoints}");   
            Console.WriteLine($"{percentageOfW:F2}%");               

        }
    }
}
