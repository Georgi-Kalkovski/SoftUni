using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks_Planner
{
    class Program
    {

        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split()
                .ToList();

            for (int i = 0; i < line.Count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                string command = input[0];

                if (command == "End")
                {
                    break;
                }
				
                string index = input[1];

                if (command == "Complete")
                {
                    if (line[i].Contains('0') || line[i].Contains('-'))
                    {
                        continue;
                    }
					
                    else
                    {
                        line[int.Parse(index)] = "0";
                        continue;
                    }
                }
				
                else if (command == "Change")
                {
                    string time = input[2];
                    if (line.Contains(index))
                    {
                        line[int.Parse(index)] = time;
                        continue;
                    }
					
                    else
                    {
                        continue;
                    }
                }
				
                else if (command == "Drop")
                {
                    if (line.Contains(index) && line[i] != "0")
                    {
                        line[int.Parse(index)] = "-1";
                        continue;
                    }
					
                    else
                    {
                        continue;
                    }
                }
				
                else if (command == "Count")
                {
                    if (index == "Completed")
                    {
                        int counter = 0;
						
                        foreach (var task in line)
                        {
                            if (task == "0")
                            {
                                counter++;
                            }
                        }
						
                        Console.WriteLine(counter);
                    }
					
                    else if (index == "Incomplete")
                    {
                        int counter = 0;
						
                        foreach (var task in line)
                        {
                            if (int.Parse(task) > 0 && int.Parse(task) < 6)
                            {
                                counter++;
                            }
                        }
						
                        Console.WriteLine(counter);
                    }
					
                    else if (index == "Dropped")
                    {
                        int counter = 0;
						
                        foreach (var task in line)
                        {
                            if (task.Contains('-'))
                            {
                                counter++;
                            }
                        }
						
                        Console.WriteLine(counter);
                    }
                }
            }
			
            for (int i = 0; i < line.Count; i++)
            {
                if (line[i] == "0")
                {
                    line.Remove(line[i]);
                    i--;
                    continue;
                }
				
                if (line[i].Contains('-'))
                {
                    line.Remove(line[i]);
                    i--;
                    continue;
                }
            }
			
            Console.WriteLine(string.Join(" ", line));
        }
    }
}
