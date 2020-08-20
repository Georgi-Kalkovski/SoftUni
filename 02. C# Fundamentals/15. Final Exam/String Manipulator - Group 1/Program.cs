using System;

namespace String_Manipulator___Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split();

                string command = input[0];
				
                if (command == "End")
                {
                    break;
                }
				
                else if (command == "Translate")
                {
                    char oldChar = char.Parse(input[1]);
                    char newChar = char.Parse(input[2]);
                    line = line.Replace(oldChar, newChar);
                    Console.WriteLine(line);
                }
				
                else if (command == "Includes")
                {
                    bool IsIncluding = false;
					
                    if (line.Contains(input[1]))
                    {
                        Console.WriteLine(!IsIncluding);
                    }
					
                    else
                    {
                        Console.WriteLine(IsIncluding);
                    }
                }
				
                else if (command == "Start")
                {
                    bool IsStarting = false;
					
                    if (line.StartsWith(input[1]))
                    {
                        Console.WriteLine(!IsStarting);
                    }
					
                    else
                    {
                        Console.WriteLine(IsStarting);
                    }
                }
				
                else if (command == "Lowercase")
                {
                    line = line.ToLower();
                    Console.WriteLine(line);
                }
				
                else if (command == "FindIndex")
                {
                    int index = line.LastIndexOf(input[1]);
                    Console.WriteLine(index);
                }
				
                else if (command == "Remove")
                {
                    int count = int.Parse(input[2]) - int.Parse(input[1]);
                    line = line.Remove(int.Parse(input[1]), count);
                    Console.WriteLine(line);
                }
            }
        }
    }
}
