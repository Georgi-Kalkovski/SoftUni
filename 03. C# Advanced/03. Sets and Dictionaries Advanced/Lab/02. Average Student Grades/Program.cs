using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, List<double>>();

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                string name = input[0];
                double grade = double.Parse(input[1]);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<double> { grade });
                }
                else
                {
                        dict[name].Add(grade);
                }
            }

            foreach (var name in dict.Keys)
            {
                int gradeCount = 0;
                Console.Write($"{name} -> ");
                foreach (var grade in dict[name])
                {
                    Console.Write(string.Join(" ",$"{grade:F2}" + " "));
                    gradeCount++;
                    if (gradeCount == dict[name].Count())
                    {
                        break;
                    }

                }
                Console.WriteLine($"(avg: {dict[name].Average():F2})");
            }
        }
    }
}
