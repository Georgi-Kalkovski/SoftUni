using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<double>>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToArray();
					
                if (input[0] == "buy")
                {
                    break;
                }

                string itemName = input[0];
                double priceValue = double.Parse(input[1]);
                double quantityValue = double.Parse(input[2]);

                if (!dict.ContainsKey(itemName))
                {

                    dict.Add(itemName, new List<double>() {0,0});
                }

                dict[itemName][0] = priceValue;
                dict[itemName][1] += quantityValue;
            }
			
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value[0] * item.Value[1]:f2}");
            }
        }
    }
}
