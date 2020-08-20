using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {

            int startingYield = int.Parse(Console.ReadLine());
            long mined = 0;                                   
            int counterOfDays = 0;                            

            if (startingYield < 100)                          
            {                                                
                Console.WriteLine(counterOfDays);             
                Console.WriteLine(mined);                     
                return;                                       
            }                                                

            for (int i = startingYield; i >= 100; i -= 10)    
            {                                               
                        mined += i - 26;                      
                        counterOfDays++;                      
            }                                                 

            mined -= 26;                                      
            Console.WriteLine(counterOfDays);                 
            Console.WriteLine(mined);                         
        }
    }
}