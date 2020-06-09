using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;                                                 
            double totalCoins = 0;                                                       
            double product = 0;  
			
            while (true)                                                                 
            {
                input = Console.ReadLine();                                              

                if (input == "Start") break;                                             

                double coin = double.Parse(input);                                       

                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2) 
                {
                    totalCoins += coin;                                                  
                }
				
                else                                                                     
                {
                    Console.WriteLine($"Cannot accept {coin}");                          
                }
            }

            while (true)                                                                 
            {
                input = Console.ReadLine();                                              

                if (input == "End")                                                      
                {
                    Console.WriteLine($"Change: {totalCoins:F2}");                       
                    break;                                                               
                }

                switch (input)                                                           
                {
                    case "Nuts": product = 2.0; break;                                   
                    case "Water": product = 0.7; break;                                  
                    case "Crisps": product = 1.5; break;                                 
                    case "Soda": product = 0.8; break;                                   
                    case "Coke": product = 1.0; break;                                   
                    default: Console.WriteLine("Invalid product"); continue;             
                }

                if (totalCoins >= product)                                               
                {
                    Console.WriteLine($"Purchased {input.ToLower()}");                   
                    totalCoins -= product;                                               
                }

                else if (totalCoins < product)                                           
                {
                    Console.WriteLine($"Sorry, not enough money");                       
                }
            }
        }
    }
}
