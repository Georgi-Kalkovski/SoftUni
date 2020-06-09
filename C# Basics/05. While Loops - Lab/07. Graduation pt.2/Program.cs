using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Graduation
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = Console.ReadLine();
            int schoolClass = 0;
            double gradesCount = 0;
            double finalMark = 0;
            int fail = 1;

            while (schoolClass < 12)
            {
                double yearGrade = double.Parse(Console.ReadLine());

                if (yearGrade >= 4.00)
                {
                    gradesCount += yearGrade;
                    schoolClass++;
                }

                else if (yearGrade < 4.00)
                {
                    fail++;

                    if (fail == 3)
                    {
                        Console.WriteLine($"{name} has been excluded at {schoolClass+1} grade");
                        return;
                    }

                }

            }
            finalMark = gradesCount / 12;
            Console.WriteLine($"{name} graduated. Average grade: {finalMark:F2}");
        }
    }
}