using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Hometown { get; set; }
    }
	
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> listOfStudents = new List<Student>();

            while (true)
            {
                List<string> currentStudent = Console.ReadLine()
                    .Split()
                    .ToList();

                if (currentStudent[0] == "end")
                {
                    break;
                }
				
                var firstName = currentStudent[0];
                var lastName = currentStudent[1];
                var age = int.Parse(currentStudent[2]);
                var hometown = currentStudent[3];

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age.ToString();
                student.Hometown = hometown;

                listOfStudents.Add(student);
            }

            var nameOfACity = Console.ReadLine();

            foreach (Student student in listOfStudents)
            {
                if (student.Hometown == nameOfACity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
}
