using System;

namespace _05._Orders
{
    class Program
    {
        public static void PriceOfProducts(string product, int quantity) 
        {                                                            
            double productPrice = 0;                                     

            switch (product)                                             
            {                                                            
                case "coffee": productPrice = 1.50; break;               
                case "water": productPrice = 1.00; break;                
                case "coke": productPrice = 1.40; break;                 
                case "snacks": productPrice = 2.00; break;               
            }      
			
            Console.WriteLine($"{productPrice*quantity:F2}");            
        }                                                                

        static void Main(string[] args)                                  
        {                                                                
            string product = Console.ReadLine();                         
            int quantity = int.Parse(Console.ReadLine());                

            PriceOfProducts(product, quantity);                          
        }
        
    }
}
