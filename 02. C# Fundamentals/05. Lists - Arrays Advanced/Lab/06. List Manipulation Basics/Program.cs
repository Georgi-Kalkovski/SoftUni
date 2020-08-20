using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()                                                        
                .Split()                                                                                
                .Select(int.Parse)                                                                      
                .ToList();                                                                              

            List<string> command = Console.ReadLine()                                                   
                .Split()                                                                                
                .ToList();                                                                              

            while (true)                                                                                
            {                                                                                           
                if (command[0] == "end") break;                                                         
                if (command[0] == "Add") input.Add(int.Parse(command[1]));                              
                if (command[0] == "Remove") input.Remove(int.Parse(command[1]));                        
                if (command[0] == "RemoveAt") input.RemoveAt(int.Parse(command[1]));                    
                if (command[0] == "Insert") input.Insert(int.Parse(command[2]), int.Parse(command[1])); 

                command = Console.ReadLine()                                                            
                .Split()                                                                                
                .ToList();                                                                              
            }           
			
            Console.WriteLine(string.Join(" ", input));                                                 
        }
    }
}
