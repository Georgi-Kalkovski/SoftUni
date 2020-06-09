using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split("#")
                .ToList();

            int water =int.Parse(Console.ReadLine());

            double effort = 0;
            int totalFire = 0;
            var cells = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                string TypeOfFire = list[i].Split(" = ")[0];
                int cell = int.Parse(list[i].Split(" = ")[1]);

                if (TypeOfFire == "High" && cell >= 81 && cell <= 125 && water >= cell)
                {
                    cells.Add(cell);
                    effort += cell * 0.25;
                    water -= cell;
                    totalFire += cell;
                }
				
                if (TypeOfFire == "Medium" && cell >= 51 && cell <= 80 && water >= cell)
                {
                    cells.Add(cell);
                    effort += cell * 0.25;
                    water -= cell;
                    totalFire += cell;
                }
				
                if (TypeOfFire == "Low" && cell >= 1 && cell <= 50 && water >= cell)
                {
                    cells.Add(cell);
                    effort += cell * 0.25;
                    water -= cell;
                    totalFire += cell;
                }
            }
			
            Console.WriteLine("Cells:");
			
            foreach (var cell in cells)
            {
                Console.WriteLine($" - {cell}");
            }
			
            Console.WriteLine($"Effort: {effort:F2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}
