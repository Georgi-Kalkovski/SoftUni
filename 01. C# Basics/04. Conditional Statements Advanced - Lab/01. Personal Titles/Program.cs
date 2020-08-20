using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Personal_Titles
{
    class Program
    {
        static void Main(string[] args)
        {

            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();

            if (gender == "m" && age >= 16)
            {
                Console.WriteLine("Mr.");
            }

            if (gender == "m" && age < 16)
            {
                Console.WriteLine("Master");
            }

            if (gender == "f" && age >= 16)
            {
                Console.WriteLine("Ms.");
            }

            if (gender == "f" && age < 16)
            {
                Console.WriteLine("Miss");
            }
        }
    }
}
