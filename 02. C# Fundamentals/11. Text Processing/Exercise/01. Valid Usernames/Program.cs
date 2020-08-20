using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split(", ")
                .ToList();
            
            for (int i =0;i < line.Count();i++)
            {
                var user = line[i];

                if (user.Length < 3 || user.Length > 16)
                {
                    line.Remove(user);
                    i--;
                    continue;
                }


                for (int j = 0; j < user.Count(); j++)
                {
                    if (!Char.IsLetterOrDigit(user[j]) && !user.Contains('-') && !user.Contains('_'))
                    {
                        line.Remove(user);
                        i--;
                        break;
                    }
                }
            }
			
            foreach (var user in line)
            {
                Console.WriteLine(user);
            }
        }
    }
}
