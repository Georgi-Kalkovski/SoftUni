using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Ticket_Combination
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            int combinationCounter = 0;


            for (char stadium = 'B'; stadium <= 'L'; stadium++)
            {
                if (stadium % 2 == 0)
                {
                    for (char entrance = 'f'; entrance >= 'a'; entrance--)
                    {
                        for (char sector = 'A'; sector <= 'C'; sector++)
                        {
                            for (int row = 1; row <= 10; row++)
                            {
                                for (int seat = 10; seat >= 1; seat--)
                                {
                                    combinationCounter++;

                                    if (combinationCounter >= number)
                                    {
                                        Console.WriteLine($"Ticket combination: {stadium}{entrance}{sector}{row}{seat}");
                                        Console.WriteLine($"Prize: {stadium + entrance + sector + row + seat} lv.");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
