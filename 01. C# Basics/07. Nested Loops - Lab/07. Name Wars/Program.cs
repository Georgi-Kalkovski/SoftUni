using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Name_Wars
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = Console.ReadLine();
            int biggestName = 0;
            
            string winnerName = string.Empty;

            while (name != "STOP")
            {
                int counter = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    
                    counter += name[i];

                    if (counter > biggestName)
                    {
                        biggestName = counter;
                        winnerName = name;
                    }
                }
                name = Console.ReadLine();
            }

            Console.WriteLine($"Winner is {winnerName} - {biggestName}!");
        }
    }
}
