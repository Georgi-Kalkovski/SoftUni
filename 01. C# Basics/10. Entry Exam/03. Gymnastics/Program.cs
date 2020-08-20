using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {

            string country = Console.ReadLine();    
            string instrument = Console.ReadLine(); 
            double difficulty = 0;                  st
            double performance = 0;                 enie

            switch (country)                        
            {                                       
                case "Russia":                      
                    switch (instrument)             
                    {                               
                        case "ribbon":              
                            difficulty += 9.100;    
                            performance += 9.400;   
                            break;                  
                        case "hoop":                
                            difficulty += 9.300;    
                            performance += 9.800;   
                            break;                  
                        case "rope":                
                            difficulty += 9.600;    
                            performance += 9.000;   
                            break;                  
                    }
                    break;                          
                                                    
                case "Bulgaria":                    
                    switch (instrument)             
                    {                               
                        case "ribbon":              
                            difficulty += 9.600;    
                            performance += 9.400;   
                            break;                  
                        case "hoop":                
                            difficulty += 9.550;    
                            performance += 9.750;   
                            break;                  
                        case "rope":                
                            difficulty += 9.500;    
                            performance += 9.400;   
                            break;                  
                    }                               
                    break;                          
                                                    
                case "Italy":                       
                    switch (instrument)             
                    {                               
                        case "ribbon":              
                            difficulty += 9.200;    
                            performance += 9.500;   
                            break;                  
                        case "hoop":                
                            difficulty += 9.450;    
                            performance += 9.350;   
                            break;                  
                        case "rope":                
                            difficulty += 9.700;    
                            performance += 9.150;   
                            break;                  
                    }                               
                    break;                          

            }
            double score = difficulty + performance;          
            double scoreLeft = 20 - score;                    
            double scorePercentage = (scoreLeft / 20) * 100;  

            Console.WriteLine($"The team of {country} get {score:F3} on {instrument}."); 
            Console.WriteLine($"{scorePercentage:F2}%");                                 
        }
    }
}
