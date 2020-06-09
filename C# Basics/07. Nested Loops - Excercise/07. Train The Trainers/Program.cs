using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {

            int numOfJury = int.Parse(Console.ReadLine());
            string topic = Console.ReadLine();
            double finalGrade = 0;
            int gradesCounter = 0;

            while (topic != "Finish")
            {
                double juryGradeTotal = 0;
				
                for (int i = 0; i < numOfJury; i++)
                {
                    double juryGrade = double.Parse(Console.ReadLine());
                    juryGradeTotal += juryGrade;
                    finalGrade += juryGrade;
                    gradesCounter++;
                }
				
                juryGradeTotal = juryGradeTotal / numOfJury;
                Console.WriteLine($"{topic} - {juryGradeTotal:F2}.");
                topic = Console.ReadLine();
				
                if (topic == "Finish")
                {
                    break;
                }
            }
			
            finalGrade = finalGrade / gradesCounter;
            Console.WriteLine($"Student's final assessment is {finalGrade:F2}.");

        }
    }
}
