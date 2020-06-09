using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                if (input[0] == "End")
                {
                    break;
                }

                string company = input[0];
                string id = input[2];

                if (!dict.ContainsKey(company))
                {
                    dict.Add(company, new List<string>());
                    dict[company].Add(id);
                }
				
                else if (dict.ContainsKey(company))
                {
                    if (dict[company].Contains(id))
                    {
                        continue;
                    }
					
                    dict[company].Add(id);
                }
            }

            dict.OrderBy(x=>x.Key);

            foreach (var company in dict)
            {
                Console.WriteLine($"{company.Key}");
				
                for (int i = 0; i < company.Value.Count(); i++)
                {
                    Console.WriteLine($"-- {company.Value[i]}");
                }
            }
        }
    }
}
