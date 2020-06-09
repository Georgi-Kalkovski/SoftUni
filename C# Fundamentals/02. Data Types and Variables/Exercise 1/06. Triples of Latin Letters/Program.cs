using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());       

            for (char i = 'a'; i < 'a' + number; i++)         
            {                                                
                for (char j = 'a'; j < 'a' + number; j++)     
                {                                            
                    for (char k = 'a'; k < 'a' + number; k++) 
                    {                                        
                        Console.WriteLine($"{i}{j}{k}");      
                    }
                }
            }
        }
    }
}
