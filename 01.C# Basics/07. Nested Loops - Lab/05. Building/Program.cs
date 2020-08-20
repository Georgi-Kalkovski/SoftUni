using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Building
{
    class Program
    {
        static void Main(string[] args)
        {

            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int z = floors; z >= 1; z--)
            {

                for (int y = 0; y < rooms; y++)
                {

                    if (z == floors)
                    {
                        Console.Write($"L{z}{y} ");
                    }

                    else if (z % 2 != 0)
                    {
                        Console.Write($"A{z}{y} ");
                    }

                    else if (z % 2 == 0)
                    {
                        Console.Write($"O{z}{y} ");
                    }

                    if (y == rooms - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
