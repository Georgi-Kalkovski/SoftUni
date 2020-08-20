using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Salary
{
    class Program
    {
        static void Main(string[] args)
        {

            int tabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i < tabs; i++)
            {
                string site = Console.ReadLine();

                if (site == "Facebook")
                    salary -= 150;
				
                if (site == "Instagram")
                    salary -= 100;
				
                if (site == "Reddit")
                    salary -= 50;

                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    return;
                }
            }
            Console.WriteLine(salary);

        }
    }
}
