using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static int LowestNum(int numOne, int numTwo, int numThree)   
        {                                                            
            int minNum = int.MaxValue;     
			
            if (numOne < minNum)                                     
            {                                                       
                minNum = numOne;                                     
            } 
			
            if (numTwo < minNum)                                     
            {                                                        
                minNum = numTwo;                                     
            }      
			
            if (numThree < minNum)                                   
            {                                                        
                minNum = numThree;                                   
            }      
			
            return minNum;                                           
        }          
		
        static void Main(string[] args)                              
        {                                                            
            int numOne = int.Parse(Console.ReadLine());              
            int numTwo = int.Parse(Console.ReadLine());              
            int numThree = int.Parse(Console.ReadLine());            

            Console.WriteLine(LowestNum(numOne, numTwo,numThree));   
        }
    }
}
