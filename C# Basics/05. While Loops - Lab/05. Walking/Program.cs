using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Walking
{
    class Program
    {
        static void Main(string[] args)
        {

            int goal = 10000;
            int steps = 0;

            while (steps < goal)
            {
                string input = Console.ReadLine();

                if (input != "Going home")
                {
                    steps += int.Parse(input);

                } 

                else if (input == "Going home")
                {
                    int returnSteps = int.Parse(Console.ReadLine());
                    steps += returnSteps;
                    break;
                }
            }

            if (steps < goal)
            {
                Console.WriteLine($"{goal - steps} more steps to reach goal.");
            }

            else
                Console.WriteLine("Goal reached! Good job!");
        }
    }
}
