using System;

namespace _08._Math_Power
{
    class Program
    {
        static double RaiseToPower(double number, int power)  
        {                                                   
            double result = Math.Pow(number, power);          
            return result;                                    
        }  
		
        static void Main(string[] args)                       
        {                                                     
            double number = double.Parse(Console.ReadLine()); 
            int power = int.Parse(Console.ReadLine());     
            Console.WriteLine(RaiseToPower(number, power));   
        }
    }
}
