using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();
			
            while (true)
            {
                string command= Console.ReadLine();

                if (command == "exam finished") break;

                string[] input = command
                    .Split("-")
                    .ToArray();

                if (input[1] == "banned")
                {
                    results.Remove(input[0]);
                    continue;
                }

                string username = input[0];
                string language = input[1];
                int points = int.Parse(input[2]);

                if (!results.ContainsKey(username))
                {
                    results.Add(username, points);
					
                    if (submissions.ContainsKey(language))
                    {
                        submissions[language]++;
                        continue;
                    }
					
                    submissions.Add(language, +1);
                    continue;
                }
                else if (results.ContainsKey(username))
                {
                    if (submissions.ContainsKey(language))
                    {
                        foreach (var biggest in results.TakeLast(1))
                        {
                            if (biggest.Value < points)
                            {
                                results[username] = points;
                            }
                        }
                    }
					
                    submissions[language]++;
                }
            }
			
            Console.WriteLine("Results:");
			
            foreach (var users in results.OrderByDescending(x => x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{users.Key} | {users.Value}");
            }

            Console.WriteLine("Submissions:");
			
            foreach (var languages in submissions.OrderByDescending(x => x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{languages.Key} - {languages.Value}");

            }
        }
    }
}
