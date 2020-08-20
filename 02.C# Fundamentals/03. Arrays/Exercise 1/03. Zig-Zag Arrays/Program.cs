using System;
using System.Linq;


namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());   

            string[] firstArray = new string[linesCount];     
            string[] secondArray = new string[linesCount];    

            for (int i = 0; i < linesCount; i++)              
            {                                                 
                string[] input = Console.ReadLine()           
                    .Split()                                  
                    .ToArray();                               

                if (i % 2 != 0)                               
                {                                            
                    firstArray[i] = input[0];                 
                    secondArray[i] = input[1];                
                }

                else                                          
                {                                             
                    firstArray[i] = input[1];                 
                    secondArray[i] = input[0];                
                }                                             
            }                                                 

            Console.WriteLine(string.Join(" ", firstArray));  
            Console.WriteLine(string.Join(" ", secondArray)); 
        }
    }
}
