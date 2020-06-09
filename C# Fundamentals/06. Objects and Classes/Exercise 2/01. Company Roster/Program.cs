using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Company_Roster
{
    class Emplyee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
	
    class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());
            var listOfDepartments = new List<Emplyee>();

            for (int i = 0; i < nLines; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToArray();

                Emplyee employee = new Emplyee();

                string name = input[0];
                double salary = double.Parse(input[1]);
                string department = input[2];

                employee.Name = name;
                employee.Salary = salary;
                employee.Department = department;

            }
        }
    }
}
