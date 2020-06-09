using System;
using System.Collections.Generic;
using System.Linq;

namespace Foggy_Squad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split()
                .ToList();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split();

                string command = input[0];
                string secondInput = input[1];

                if (command == "Join")
                {
                    line.Add(secondInput);
                }
				
                else if (command == "Jump")
                {
                    if (line.Count >= int.Parse(input[2]))
                    line.Insert(int.Parse(input[2]), secondInput);
                }
				
                else if (command == "Dive")
                {
                    if (line.Count >= int.Parse(input[1]))
                        line.RemoveAt(int.Parse(secondInput));
                }
				
                else if (command == "First" || command == "Last")
                {
                    if (command == "First")
                    {
                        for (int i = 0; i < int.Parse(secondInput); i++)
                        {
                            if (i < line.Count)
                            {
                                Console.Write(line[i] + " ");
                            }
							
                            else
                            {
                                break;
                            }
                        }
						
                        Console.WriteLine();
                    }
					
                    else if (command == "Last")
                    {
                        for (int i = int.Parse(secondInput)+2; i < line.Count; i++)
                        {
                            if (i <= line.Count)
                            {
                                Console.Write(line[i] + " ");
                            }
                        }
						
                        Console.WriteLine();
                    }
                }
				
                else if (command == "Print")
                {
                    if (secondInput == "Normal")
                    {
                        Console.Write("Frogs: ");
                        Console.WriteLine(string.Join(" ", line));
                        break;
                    }
					
                    else if (secondInput == "Reversed")
                    {
                        line.Reverse();
                        Console.Write("Frogs: ");
                        Console.WriteLine(string.Join(" ", line));
                        break;
                    }
                }
            }
        }
    }
}
