using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!dict.ContainsKey(student))
                {
                    dict.Add(student, new List<double>());
                    dict[student].Add(grade);
                }
				
                else if (dict.ContainsKey(student))
                {
                    dict[student].Add(grade);
                }
            }

            foreach (var student in dict)
            {

                double numberOfGrades = student.Value.Count();
                double averageGrade = student.Value.Sum() / numberOfGrades;

                if (averageGrade >= 4.5)
                {
                    student.Value.Add(averageGrade);
                }
            }

            foreach (var student in dict.OrderByDescending(x => x.Value.Last()))
            {
                if (student.Value.Average() >= 4.5)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value.Last():F2}");
                }
            }
		}
    }
}
