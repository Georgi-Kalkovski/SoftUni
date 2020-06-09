using System;

namespace _11._Math_operations
{
    class Program
    {
        private static double Calculate(int a, string @operator, int b)  
        {                                                                
            double result = 0;    
			
            switch (@operator)                                           
            {                                                            
                case "/": result = a / b; break;                         
                case "*": result = a * b; break;                         
                case "+": result = a + b; break;                         
                case "-": result = a - b; break;                         
            }           
			
            return result;                                               
        }      
		
        static void Main(string[] args)                                  
        {                                                                
            int a = int.Parse(Console.ReadLine());                       
            string @operator = Console.ReadLine();                       
            int b = int.Parse(Console.ReadLine());                       
            Console.WriteLine(Calculate(a, @operator, b));               
        }
    }
}
