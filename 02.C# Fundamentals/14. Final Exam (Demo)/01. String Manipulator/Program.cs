using System;
using System.Linq;

namespace _01._String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = string.Empty;

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split()
                    .ToArray();

                string keyWord = command[0];
                string input = string.Empty;

                if (keyWord != "Print" && keyWord != "End")
                {
                    input = command[1];
                }

                if (keyWord == "End")
                {
                    break;
                }
				
                if (keyWord == "Add")
                {
                    word += input;
                }
				
                if (keyWord == "Upgrade")
                {
                    char ch1 = command[1][0];
                    char ch2 = command[1][0];
                    ch2++;
                    word = word.Replace(ch1, ch2);
                }
				
                if (keyWord == "Index")
                {
                    bool contains = false;
                    char ch1 = command[1][0];
					
                    for (int i = 0; i < word.Length; i++)
                    {

                        if (word[i] == ch1)
                        {
                            Console.Write($"{i} ");
                            contains = true;
                        }
						
                        else
                        {
                            continue;
                        }
                    }

                    if (contains == false)
                    {
                        Console.Write("None");
                    }
					
                    Console.WriteLine();
                }
				
                if (keyWord == "Remove")
                {
                    word = word.Replace(input, "");
                }
				
                if (keyWord == "Print")
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
