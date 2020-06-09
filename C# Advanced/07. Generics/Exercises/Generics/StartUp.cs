using System;
using System.Collections.Generic;
using System.Linq;

namespace Workshop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CurrentLinkedList<int> list = new CurrentLinkedList<int>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var tokens = Console.ReadLine().Split();

                string command = tokens[0];
                int number = int.Parse(tokens[1]);

                switch (command)
                {
                    case "Add":
                        list.Add(number);
                        break;
                    case "Remove":
                        list.Remove(number);
                        break;
                }
            }

            Console.WriteLine(list.Count);

            foreach (int number in list)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}
