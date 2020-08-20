using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();            
            double a = double.Parse(Console.ReadLine());    
            double b = double.Parse(Console.ReadLine());    

            switch (command)                                
            {                                               
                case "add":                                 
                    Add(a, b);                              
                    break;                                  
                case "multiply":                            
                    Multiply(a, b);                         
                    break;                                  
                case "subtract":                            
                    Subtract(a, b);                         
                    break;                                  
                case "divide":                              
                    Divide(a, b);                           
                    break;                                  
            }                                               
        }                  
        
        private static void Add(double a, double b)         
        {                                                 
            Console.WriteLine(a+b);                         
        }     
		
        private static void Multiply(double a, double b)    
        {                                                 
            Console.WriteLine(a * b);                       
        }      
		
        private static void Subtract(double a, double b)    
        {                                                  
            Console.WriteLine(a - b);                       
        }     
		
        private static void Divide(double a, double b)      
        {                                                 
            Console.WriteLine(a / b);                       
        }
    }
}
