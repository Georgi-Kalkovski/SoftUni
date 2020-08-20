using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int listLength = int.Parse(Console.ReadLine());
			
            List<string> listOfNames = new List<string>();

            for (int i = 0; i < listLength; i++)
            {
                List<string> goingOrNot = Console.ReadLine()
                    .Split()
                    .ToList();
					
                if (goingOrNot[2] == "not")
                {
                    if (listOfNames.Contains(goingOrNot[0]))
                    {
                        listOfNames.Remove(goingOrNot[0]);
                    }
					
                    else
                    {
                        Console.WriteLine($"{goingOrNot[0]} is not in the list!");
                    }
                }
				
                else if (goingOrNot[2] == "going!")
                {
                    if (listOfNames.Contains(goingOrNot[0]))
                    {
                        Console.WriteLine($"{goingOrNot[0]} is already in the list!");
                    }
					
                    else
                    {
                        listOfNames.Add(goingOrNot[0]);
                    }
                }
            }
			
            for (int i = 0; i < listOfNames.Count; i++)
            {
                Console.WriteLine(listOfNames[i]);
            }
        }
    }
}
