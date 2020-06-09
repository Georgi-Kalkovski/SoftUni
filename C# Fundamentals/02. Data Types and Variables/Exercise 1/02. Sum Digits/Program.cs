using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {

            string number = Console.ReadLine();  
            var sum = 0;                         

            foreach (var singleNumber in number) 
            {                                    
                sum += singleNumber - 48;        
            }                                    

            Console.WriteLine(sum);              
        }
    }
}
