using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {

            double salary = double.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            double salaryMinimal = double.Parse(Console.ReadLine());

            double socialScholarship = Math.Floor(salaryMinimal * 0.35);
            double normalScholarship = Math.Floor(grade * 25);
            double scolarship = Math.Max(socialScholarship, normalScholarship);

            if (grade <= 4.50)
            {
                Console.WriteLine("You cannot get a scholarship!");

            }

            else if (grade > 4.50 && grade < 5.50)
            {
                if (salary > salaryMinimal)
                {
                    Console.WriteLine("You cannot get a scholarship!");
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                }
            }
            else if (grade >= 5.50)
            {
                if (salary < salaryMinimal)
                {
                    if (socialScholarship == scolarship)
                    {
                        Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                    }
                    else if (normalScholarship == scolarship)
                    {
                        Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(normalScholarship)} BGN");
                    }
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(normalScholarship)} BGN");
            }
        }
    }
}
