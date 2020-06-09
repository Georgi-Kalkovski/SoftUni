using System;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());                 
            int[] wagonsArray = new int [wagons];                       
            int sum = 0;             
			
            for (int i = 0; i < wagons; i++)                            
            {                                                         
                int peoplePerWagon = int.Parse(Console.ReadLine());     
                sum += peoplePerWagon;                                  
                wagonsArray[i] = peoplePerWagon; 
				
                if (i == wagons - 1)                                    
                {                                                   
                    for (int j = 0; j <= wagonsArray.Length - 1; j++)   
                    {                                                  
                        Console.Write(wagonsArray[j] + " ");            
                    }   
					
                    Console.WriteLine();                                
                    Console.WriteLine(sum);                             
                }
            }
        }
    }
}
