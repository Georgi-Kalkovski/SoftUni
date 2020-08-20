using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        
        static int SumNumOneAndTwo                                 
            (int numOne,                                           
            int numTwo,                                            
            int sum)                                               
        {                             
            sum = numOne + numTwo;                                 
            return sum;                                            
        }       
		
        static int SubNumOneAndTwoWithThree                        
            (int numOne,                                           
            int numTwo,                                            
            int numThree,                                          
            int sum,                                               
            int sub)                                               
        {         
            sub = SumNumOneAndTwo(numOne, numTwo, sum) - numThree; 
            return sub;                                            
        }         

        static void Main(string[] args)                            
        {                                                          
            int numOne = int.Parse(Console.ReadLine());            
            int numTwo = int.Parse(Console.ReadLine());            
            int numThree = int.Parse(Console.ReadLine());          
            int sum = 0;                                           
            int sub = 0;                                           

            Console.WriteLine(SubNumOneAndTwoWithThree             
                (numOne,                                           
                numTwo,                                            
                numThree,                                            
                sum,                                                 
                sub));                                               
        }                                                            
    }
}
