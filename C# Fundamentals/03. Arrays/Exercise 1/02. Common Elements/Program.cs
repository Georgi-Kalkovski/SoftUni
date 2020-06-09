using System;
using System.Linq;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArrayOne = Console.ReadLine()        
                .Split()                                       
                .ToArray();                                    

            string[] inputArrayTwo = Console.ReadLine()        
                .Split()                                       
                .ToArray();                                    

            for (int i = 0; i < inputArrayTwo.Length; i++)     
            {                                                  
                for (int j = 0; j < inputArrayOne.Length; j++) 
                {                                              
                    if (inputArrayTwo[i] == inputArrayOne[j])  
                    {                                         
                        Console.Write(inputArrayTwo[i] + " "); 
                    }
                }
            }
        }
    }
}
