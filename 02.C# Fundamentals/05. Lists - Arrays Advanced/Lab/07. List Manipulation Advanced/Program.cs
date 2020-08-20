using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void DoesInputContainsThisNumber(List<string> command, List<int> input)
        {
            if (input.Contains(int.Parse(command[1])))
            {
                Console.WriteLine("Yes");
            }
			
            else
            {
                Console.WriteLine("No such number");
            }
        }
		
        static void CheckIfNumberIsEven(List<string> command, List<int> input)
        {
            string evenNums = string.Empty;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] % 2 == 0)
                {
                    evenNums += input[i] + " ";
                }
            }
			
            Console.WriteLine(evenNums);
        }
		
        static void CheckIfNumberIsOdd(List<string> command, List<int> input)
        {
            string oddNums = string.Empty;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] % 2 != 0)
                {
                    oddNums += input[i] + " ";
                }
            }
			
            Console.WriteLine(oddNums);
        }
		
        static void SumAllNums(List<string> command, List<int> input)
        {
            int sumAll = 0;

            for (int i = 0; i < input.Count; i++)
            {
                sumAll += input[i];
            }
			
            Console.WriteLine(sumAll);
        }
		
        static void FilterNums(List<string> command, List<int> input)
        {
            int index = int.Parse(command[2]);

            switch (command[1])
            {
                case "<":
                    Console.WriteLine(string.Join(" ", input.Where(x => x < index)));
                    break;
                case "<=":
                    Console.WriteLine(string.Join(" ", input.Where(x => x <= index)));
                    break;
                case ">":
                    Console.WriteLine(string.Join(" ", input.Where(x => x > index)));
                    break;
                case ">=":
                    Console.WriteLine(string.Join(" ", input.Where(x => x >= index)));
                    break;
            }
        }
		
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()                                                        
                .Split()                                                                                
                .Select(int.Parse)                                                                      
                .ToList();                                                                              

            List<string> command = Console.ReadLine()                                                   
                .Split()                                                                                
                .ToList();

            bool ifThereIsChange = false;

            while (true)                                                                                
            {
                if (command[0] == "Add") input.Add(int.Parse(command[1]));
                if (command[0] == "Remove") input.Remove(int.Parse(command[1]));
                if (command[0] == "RemoveAt") input.RemoveAt(int.Parse(command[1]));
                if (command[0] == "Insert") input.Insert(int.Parse(command[2]), int.Parse(command[1]));
                if (command[0] == "Contains") DoesInputContainsThisNumber(command, input);
                if (command[0] == "PrintEven") CheckIfNumberIsEven(command, input);
                if (command[0] == "PrintOdd") CheckIfNumberIsOdd(command, input);
                if (command[0] == "GetSum") SumAllNums(command, input);
                if (command[0] == "Filter") FilterNums(command, input);

                if (command[0] == "Add" || command[0] == "Remove" || command[0] == "RemoveAt" || command[0] == "Insert")
                {
                    ifThereIsChange = true;
                }
				
                if (command[0] == "end" && ifThereIsChange)
                {
                    Console.WriteLine(string.Join(" ", input));
                    break;
                }
				
                if (command[0] == "end") break;

                command = Console.ReadLine()                                                            
                .Split()                                                                                
                .ToList();
            }
        }
    }
}
