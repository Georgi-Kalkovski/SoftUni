using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input1 = Console.ReadLine()                          
                .Split()                                                   
                .Select(int.Parse)                                         
                .ToList();          
				
            List<int> input2 = Console.ReadLine()                          
                .Split()                                                   
                .Select(int.Parse)                                         
                .ToList();                                                 

            List<int> result = new List<int>();                            

            for (int i = 0; i < Math.Max(input1.Count,input2.Count); i++)  
            {                                                             
                if (i < input1.Count)                                      
                {                                                         
                    result.Add(input1[i]);                                 
                }  
				
                if (i < input2.Count)                                      
                {                                                         
                    result.Add(input2[i]);                                 
                }                                                         
            }        
			
            Console.WriteLine(string.Join(" ", result));                   
        }
    }
}
