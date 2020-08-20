using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem
{
    public class StudentSystem
    {


        private Dictionary<string, Student> student;

        public Dictionary<string, Student> Student
        {
            get { return student; }
            private set { student = value; }
        }

        public StudentSystem()
        {
            Student = new Dictionary<string, Student>();
        }

        public void StudentInfo()
        {
            string[] inputInfo = Console.ReadLine()
                .Split();

            Create(inputInfo, Student);
            Show(inputInfo, Student);
            Exit(inputInfo);
        }

        static void Create(string[] inputInfo, Dictionary<string, Student> Student)
        {
            if (inputInfo[0] == "Create")
            {
                var name = inputInfo[1];
                var age = int.Parse(inputInfo[2]);
                var grade = double.Parse(inputInfo[3]);

                if (!Student.ContainsKey(name))
                {
                    var student = new Student(name, age, grade);
                    Student[name] = student;
                }
            }
        }

        static void Show(string[] inputInfo, Dictionary<string, Student> Student)
        {
            if (inputInfo[0] == "Show")
            {
                var name = inputInfo[1];
                if (Student.ContainsKey(name))
                {
                    var student = Student[name];
                    string view = $"{student.Name} is {student.Age} years old.";

                    if (student.Grade >= 5.00)
                    {
                        view += " Excellent student.";
                    }
                    else if (student.Grade < 5.00 && student.Grade >= 3.50)
                    {
                        view += " Average student.";
                    }
                    else
                    {
                        view += " Very nice person.";
                    }

                    Console.WriteLine(view);
                }

            }
        }

        static void Exit(string[] inputInfo)
        {
            if (inputInfo[0] == "Exit")
            {
                Environment.Exit(0);
            }
        }
    }
}
