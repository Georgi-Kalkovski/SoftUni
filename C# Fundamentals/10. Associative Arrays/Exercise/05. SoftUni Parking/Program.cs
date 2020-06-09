using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> dict = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();
                string command = input[0];
                string username = input[1];

                if (command == "unregister" && !dict.ContainsKey(username))
                {
                    Console.WriteLine($"ERROR: user {username} not found");
                    continue;
                }
				
                else if (command == "unregister" && dict.ContainsKey(username))
                {
                    Console.WriteLine($"{username} unregistered successfully");
                    dict.Remove(username);
                    continue;
                }

                string licensePlate = input[2];

                if (command == "register" && !dict.ContainsKey(username))
                {
                    dict.Add(username, licensePlate);
                    Console.WriteLine($"{username} registered {licensePlate} successfully");
                    continue;
                }
				
                else if (command == "register" && dict.ContainsKey(username))
                {
                    Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                    continue;
                }
            }

            foreach (var user in dict)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
