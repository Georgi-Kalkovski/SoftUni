using System;

namespace _10._Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch = char.Parse(Console.ReadLine()); 
           
            if (ch > 96 && ch < 123)                  
            {                                         
                Console.WriteLine("lower-case");      
            }                                         
        
            if (ch > 64 && ch < 91)                   
            {                                         
                Console.WriteLine("upper-case");      
            }
        }
    }
}
