using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstChar = int.Parse(Console.ReadLine());             
            int secondChar = int.Parse(Console.ReadLine());            

            for (char i = (char)firstChar; i <= (char)secondChar; i++) 
            {                                                          
                Console.Write(i + " ");                                
            }
        }
    }
}
