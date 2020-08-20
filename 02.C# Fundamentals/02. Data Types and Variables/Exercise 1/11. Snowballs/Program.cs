using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfSnowballs = int.Parse(Console.ReadLine());    
            int bestSnow = int.MinValue;                              
            int bestTime = int.MinValue;                              
            int bestQuality = int.MinValue;                           
            BigInteger bestValue = -999999999999;                     

            for (int i = 0; i < numberOfSnowballs; i++)               
            {                                                         
                int snowballSnow = int.Parse(Console.ReadLine());     
                int snowballTime = int.Parse(Console.ReadLine());     
                int snowballQuality = int.Parse(Console.ReadLine());  

                BigInteger snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality); 
				
                if (snowballValue >= bestValue)          
                {                                        
                    bestSnow = snowballSnow;             
                    bestTime = snowballTime;             
                    bestQuality = snowballQuality;       
                    bestValue = snowballValue;        
                }                                                                                       
            }     
            
            Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQuality})");               
        }                                                                             
    }
}
