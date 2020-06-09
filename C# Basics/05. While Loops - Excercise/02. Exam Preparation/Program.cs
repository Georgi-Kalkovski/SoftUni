using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {

            string nameOfProblem = string.Empty;
            double scoreCount = 0;
            int problemsCount = 0;
            int failCount = 0;
            string lastProblem = string.Empty;

            int allowedFails = int.Parse(Console.ReadLine());
            
            while (nameOfProblem != "Enough")
            {
                nameOfProblem = Console.ReadLine();
				
                if (nameOfProblem == "Enough")
                {
                    break;
                }
				
                double score = double.Parse(Console.ReadLine());
                scoreCount += score;
                problemsCount++;
                lastProblem = nameOfProblem;
				
                if (score <= 4)
                {
                    failCount++;
                }
				
                if (allowedFails == failCount)
                {
                    Console.WriteLine($"You need a break, {allowedFails} poor grades.");
                    return;
                }
            }
			
            double finalGrade = scoreCount / problemsCount;
			
            Console.WriteLine($"Average score: {finalGrade:F2}");
            Console.WriteLine($"Number of problems: {problemsCount}");
            Console.WriteLine($"Last problem: {lastProblem}");

        }
    }
}
