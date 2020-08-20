using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()           
                .Split()                                   
                .Select(int.Parse)                         
                .ToList();                                 

            List<int> result = new List<int>();            

            for (int i = 0; i < input.Count; i++)          
            {                                             
                if (input[i] >= 0)                         
                {                                         
                    result.Add(input[i]);                  
                }                                         
            }                                             

            result.Reverse();                              

            if (result.Count == 0)                         
            {                                         
                Console.WriteLine("empty");                
            }    
			
            Console.WriteLine(string.Join(" ", result));   
            
        }
    }
}
