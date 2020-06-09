using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfSongs = Console.ReadLine()
                .Split(", ")
                .ToList();

            Queue<string> queueOfSongs = new Queue<string>(listOfSongs);

            while (queueOfSongs.Count > 0)
            {
                List<string> input = Console.ReadLine().Split().ToList();
                string command = input[0];

                if (command == "Play")
                {
                    queueOfSongs.Dequeue();
                    continue;
                }
				
                else if (command == "Add")
                {
                    string song = string.Empty;
                    song += input[1];
					
                    for (int i = 2; i < input.Count; i++)
                    {

                        song += " " + input[i];
                    }
					
                    if (queueOfSongs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
					
                    else
                    {
                        queueOfSongs.Enqueue(song);
                    }
                    continue;
                }
				
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queueOfSongs));
                    continue;
                }
            }
			
            Console.WriteLine("No more songs!");
        }
    }
}
