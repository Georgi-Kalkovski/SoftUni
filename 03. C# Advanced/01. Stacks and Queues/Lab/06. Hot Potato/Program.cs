using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var children = Console.ReadLine().Split(' ');

            var number = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(children);

            while (queue.Count != 1)
            {

                for (int i = 1; i < number; i++)
                {

                    queue.Enqueue(queue.Dequeue()); // slaga otzad na opashkata i maha otpred ednovremenno

                }

                Console.WriteLine($"Removed {queue.Dequeue()}"); // printira i premahva

            }

            Console.WriteLine($"Last is {queue.Dequeue()}"); // posledniq biva printiran i premahnat
        }
    }
}
