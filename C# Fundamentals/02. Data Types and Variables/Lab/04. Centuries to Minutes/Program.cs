using System;

namespace _04._Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;                  
            double days = years * 365.2422;               
            int trueDays = (int)days;                     
            int hours = (int)days * 24;                   
            long minutes = hours * 60;                    
            
            Console.Write($" {centuries} centuries =");   
            Console.Write($" {years} years =");           
            Console.Write($" {trueDays} days =");         
            Console.Write($" {hours} hours =");           
            Console.Write($" {minutes} minutes");         
        }
    }
}
