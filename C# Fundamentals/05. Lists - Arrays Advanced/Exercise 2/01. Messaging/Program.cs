using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string text = Console.ReadLine();
			
            foreach (int i in listOfNumbers)
            {
                int sum = i.ToString().Sum(c => c - '0');
                int counter = 1;
                int repeat = 0;
				
                for (int j = 0; j<= text.Length-1; j++)
                {
                    if (counter == sum)
                    {
                        if (repeat == 1)
                        {
                            Console.Write(text[j]);
                            text = text.Remove(j, 1);
                            break;
                        }
						
                        else
                        {
                            Console.Write(text[j+1]);
                            text = text.Remove(j+1, 1);
                            break;
                        }
                    }
					
                    if (counter == text.Length-1 && text[counter] != sum)
                    {
                        j -= counter;
                        repeat ++;
                    }
					
                    counter++;
                }
            }
        }
    }
}
