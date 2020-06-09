using System;
using System.Collections.Generic;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());                 

            List<string> productsInList = new List<string>(n);     

            for (int i = 0; i < n; i++)                            
            {                                                      
                string product = Console.ReadLine();               
                productsInList.Add(product);                       
            }   
			
            productsInList.Sort();                                 

            for (int i = 0; i < n; i++)                            
            {                                                     
                Console.WriteLine($"{i+1}.{productsInList[i]}");   
            }
        }
    }
}
