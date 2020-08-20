using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> paintings = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                List<string> command = Console.ReadLine()
                    .Split()
                    .ToList();

                if (command[0] == "END")
                {
                    Console.WriteLine(string.Join(" ", paintings));
                    break;
                }

                if (command[0] == "Change")
                {
                    for (int i = 0; i < paintings.Count; i++)
                    {
                        if (paintings[i] == int.Parse(command[1]))
                        {
                            paintings.Insert(i + 1, int.Parse(command[2]));
                            paintings.RemoveAt(i);
                            break;
                        }
                    }
                }

                if (command[0] == "Hide")
                {
                    for (int i = 0; i < paintings.Count; i++)
                    {
                        if (paintings[i] == int.Parse(command[1]))
                        {
                            paintings.RemoveAt(i);
                            break;
                        }
                    }
                }

                if (command[0] == "Switch")
                {
                    int firstIndex = 0;
                    int secondIndex = 0;
                    bool firstIndexFound = false;
                    bool secondIndexFound = false;

                    for (int i = 0; i < paintings.Count; i++)
                    {
                        if (paintings[i] == int.Parse(command[1]) && firstIndexFound != true)
                        {
                            firstIndex = i;
                            firstIndexFound = true;
                        }
						
                        if (paintings[i] == int.Parse(command[2]) && secondIndexFound != true)
                        {
                            secondIndex = i;
                            secondIndexFound = true;
                        }
                    }
					
                    if (firstIndexFound && secondIndexFound)
                    {
                        int temp = paintings[firstIndex];
                        paintings[firstIndex] = paintings[secondIndex];
                        paintings[secondIndex] = temp;
                    }
                }

                if (command[0] == "Insert")
                {
                    if (int.Parse(command[1]) < paintings.Count && int.Parse(command[1]) > -1)
                    {
                        paintings.Insert(int.Parse(command[1]) + 1, int.Parse(command[2]));
                    }
                }

                if (command[0] == "Reverse")
                {
                    paintings.Reverse();
                }
            }
        }
    }
}
