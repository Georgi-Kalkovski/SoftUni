using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Cake
{
    class Program
    {
        static void Main(string[] args)
        {

            int cakeX = int.Parse(Console.ReadLine());
            int cakeY = int.Parse(Console.ReadLine());

            int cakeArea = cakeX * cakeY;

            string input = string.Empty;

            while (true)
            {
                input = Console.ReadLine();

                if (input != "STOP")
                {
                    int slicesCounter = int.Parse(input);
                    cakeArea -= slicesCounter;

                    if (cakeArea < 0)
                    {
                        Console.WriteLine($"No more cake left! You need {Math.Abs(cakeArea)} pieces more.");
                        return;
                    }
                }

                else if (input == "STOP")
                {
                    Console.WriteLine($"{cakeArea} pieces are left.");
                    return;
                }
            }
        }
    }
}
