using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" : ")
                    .ToArray();

                if (input[0] == "end")
                {
                    break;
                }

                string course = input[0];
                string student = input[1];

                if (!dict.ContainsKey(course))
                {
                    dict.Add(course, new List<string>());
                    dict[course].Add(student);
                    dict[course].Sort();
                }
				
                else if (dict.ContainsKey(course))
                {
                    dict[course].Add(student);
                    dict[course].Sort();
                }
            }

            var ordered = dict.OrderByDescending(x => x.Value.Count());

            foreach (var course in ordered)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count()}");
				
                for (int i = 0; i < course.Value.Count(); i++)
                {
                    Console.WriteLine($"-- {course.Value[i]}");
                }
            }
        }
    }
}
