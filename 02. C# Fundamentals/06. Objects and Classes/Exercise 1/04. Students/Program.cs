using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }
		
        public Student(string firstName, string secondName, double grade)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Grade = grade;
        }
		
        public override string ToString()
        {
            return $"{this.FirstName} {this.SecondName}: {this.Grade:F2}";
        }
    }
	
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            var students = new List<Student>();
			
            for (int i = 0; i < countOfStudents; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                string firstName = input[0];
                string secondName = input[1];
                double grade = double.Parse(input[2]);

                Student student = new Student(firstName, secondName, grade);

                student.FirstName = firstName;
                student.SecondName = secondName;
                student.Grade = grade;

                students.Add(student);
            }
			
            students = students.OrderByDescending(x => x.Grade).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, students));
        }
    }
}
