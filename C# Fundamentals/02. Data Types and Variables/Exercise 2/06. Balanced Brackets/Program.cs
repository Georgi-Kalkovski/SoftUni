using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());             
            int openedBrackets = 0;                            
            int closedBrackets = 0;                            

            for (int i = 0; i < n; i++)                        
            {                                                  
                string input = Console.ReadLine();             

                if (input == "(")                              
                {                                              
                    openedBrackets++;                          

                    if (openedBrackets - closedBrackets == 2)  
                    {                                          
                        Console.WriteLine("UNBALANCED");       
                        return;                                
                    }                                          
                }                                              

                if (input == ")")                              
                {                                              
                    closedBrackets++;                          

                    if (openedBrackets - closedBrackets != 0)  
                    {                                          
                        Console.WriteLine("UNBALANCED");       
                        return;                                
                    }                                          
                }                                              
            }                                                  

            if (openedBrackets != closedBrackets)              
            {                                                  
                Console.WriteLine("UNBALANCED");               
            }                                                  

            else                                               
            {                                                  
                Console.WriteLine("BALANCED");                 
            }
        }
    }
}
