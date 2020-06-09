using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            double finalSum = 0;

            for (int i = 0; i < line.Count(); i++)
            {
                char[] singleString = line[i].ToString().ToCharArray();
                string currentNumAsString = null;
                double currentSum = 0;

                foreach (var @char in singleString)
                {
                    if (Char.IsNumber(@char))
                    {
                        currentNumAsString += @char;
                    }
                }

                double trueCurrentNum = double.Parse(currentNumAsString);

                if (Char.IsUpper(singleString[0]))
                {
                    currentSum += trueCurrentNum / (singleString[0] - 64);
                }
				
                else if (Char.IsLower(singleString[0]))
                {
                    currentSum += trueCurrentNum * (singleString[0] - 96);
                }

                if (Char.IsUpper(singleString[singleString.Count() - 1]))
                {
                    finalSum += currentSum - (singleString[singleString.Count() - 1] - 64);
                }
				
                else if (Char.IsLower(singleString[singleString.Count() - 1]))
                {
                    finalSum += currentSum + (singleString[singleString.Count() - 1] - 96);
                }
            }

            Console.WriteLine($"{finalSum:F2}");
        }
    }
}
