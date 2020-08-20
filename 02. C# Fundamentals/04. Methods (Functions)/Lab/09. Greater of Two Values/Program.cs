using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        private static string GetMax(string mainInput, string input1, string input2)
        {                                                                           
            if (mainInput == "int")                                                 
            {                                                                       
                int int1 = int.Parse(input1);                                       
                int int2 = int.Parse(input2);                                       
                if (int1 > int2) return input1;                                     
                if (int1 < int2) return input2;                                     
            }
			
            else if (mainInput == "char")                                           
            {                                                                      
                char ch1 = char.Parse(input1);                                      
                char ch2 = char.Parse(input2);                                      
                if (ch1 > ch2) return input1;                                       
                if (ch1 < ch2) return input2;                                       
            }     
			
            if (mainInput == "string")                                              
            {                                                                       
                if (String.Compare(input1, input1) > 0) return input1;              
                if (String.Compare(input1, input2) < 0) return input2;              
            }         
			
            return input1;                                                          
        }              
		
        static void Main(string[] args)                                             
        {                                                                           
            string mainInput = Console.ReadLine();                                  
            string input1 = Console.ReadLine();                                     
            string input2 = Console.ReadLine();                                     

            Console.WriteLine(GetMax(mainInput, input1, input2));                   
        }
    }
}

