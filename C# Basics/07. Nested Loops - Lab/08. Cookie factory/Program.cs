using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Cookie_factory
{
    class Program
    {
        static void Main(string[] args)
        {

            int batch = int.Parse(Console.ReadLine());

            bool eggs = false;
            bool sugar = false;
            bool flour = false;

            for (int i = 0; i < batch;)
            {
                string input = string.Empty;

                while (input != "Bake")
                {
                    input = Console.ReadLine();

                    if (input == "eggs") eggs = true;

                    if (input == "sugar") sugar = true;

                    if (input == "flour") flour = true;

                    if (input == "Bake!")
                    {

                        if (eggs && sugar && flour)
                        {
                            i++;
                            Console.WriteLine($"Baking batch number {i}...");
                            eggs = false;
                            sugar = false;
                            flour = false;

                            if (i == batch)
                            {
                                return;
                            }
                        }

                        else
                        {
                            Console.WriteLine("The batter should contain flour, eggs and sugar!");
                        }
                    }
                }
            }
        }
    }
}
