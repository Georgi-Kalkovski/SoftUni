using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Moving
{
    class Program
    {
        static void Main(string[] args)
        {

            int spaceWidth = int.Parse(Console.ReadLine());
            int spaceLength = int.Parse(Console.ReadLine());
            int spaceHeigth = int.Parse(Console.ReadLine());
            int boxes = 0;
            int leftPlus = 0;
            int leftMinus = 0;

            int volume = spaceHeigth * spaceLength * spaceWidth;

            while (boxes < volume)
            {
                string input = Console.ReadLine();

                if (input == "Done")
                {
                    leftPlus = volume - boxes;
                    Console.WriteLine($"{leftPlus} Cubic meters left.");
                    return;
                }

                int box = int.Parse(input);

                boxes += box;
                
            }

            leftMinus = boxes - volume;
            Console.WriteLine($"No more free space! You need {leftMinus} Cubic meters more.");
        }
    }
}
