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
            // vuvejdame zaplatata na roditelq
            double grade = double.Parse(Console.ReadLine());
            // vuvejdame ocenkata na uchenika
            double salaryMinimal = double.Parse(Console.ReadLine());
            // vuvejdame minimalnata zaplata

            double socialScholarship = Math.Floor(salaryMinimal * 0.35);
            // nmirame stipendiqta po dohod
            double normalScholarship = Math.Floor(grade * 25);
            // namirame stipendiqta po ocenka
            double scolarship = Math.Max(socialScholarship, normalScholarship);
            // izbirame po-visokata stoinost sprqmo dvte stipendii

            if (grade <= 4.50)
            // ako ocenkata e pod 4.50
            {
                Console.WriteLine("You cannot get a scholarship!");
                // vadim na konzolata "You cannot get a scholarship!"

            }

            else if (grade > 4.50 && grade < 5.50)
            // ako zaplatata e nad 4.50 i pod 5.50
            {
                if (salary > salaryMinimal)
                // ako zaplata e nad minimalnata
                {
                    Console.WriteLine("You cannot get a scholarship!");
                    // vadim na konzolata "You cannot get a scholarship!"
                }
                else
                // ako zaplatata e po-malka ot minimalnata
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                    // zima se stipendiq po dohod i pishem kolko e tq
                    // zakruglqme do po-niskoto chislo
                }
            }
            else if (grade >= 5.50)
            // ako ocenkata e nad 5.50
            {
                if (salary < salaryMinimal)
                // ako zaplatata e po-malka ot minimalnata
                {
                    if (socialScholarship == scolarship)
                    // ako parite za stipendiq po dohod sa poveche
                    {
                        Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                        // zima se stipendiq po dohod i pishem kolko e tq
                        // zakruglqme do po-niskoto chislo
                    }
                    else if (normalScholarship == scolarship)
                    // ako parite za stipendiq po ocenka sa poveche
                    {
                        Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(normalScholarship)} BGN");
                        // zima se stipendiq po ocenka i pishem kolko e tq
                        // zakruglqme do po-niskoto chislo
                    }
                }
                else
                // ako zaplatata e po-golqma ot minimalnata
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(normalScholarship)} BGN");
                    // zima se stipendiq po ocenka i pishem kolko e tq
                    // zakruglqme do po-niskoto chislo
                }
            }
        }
    }
}
