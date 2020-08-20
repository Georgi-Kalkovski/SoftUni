using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int colorsOfClothes = int.Parse(Console.ReadLine());
            var colors = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < colorsOfClothes; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] { " -> " }, StringSplitOptions.None)
                    .ToArray();

                string color = input[0];

                string[] items = input[1]
                    .Split(",")
                    .ToArray();
                foreach (var item in items)
                {
                    if (!colors.ContainsKey(color))
                    {
                        colors[color] = new Dictionary<string, int>();
                        colors[color].Add(item, +1);
                        continue;
                    }
                    else if (!colors[color].ContainsKey(item))
                    {
                        colors[color].Add(item, +1);
                        continue;
                    }
                        colors[color][item]++;
                }
            }

            string[] searchingFor = Console.ReadLine().Split();

            foreach (var color in colors)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var item in color.Value)
                {
                    if (color.Key == searchingFor[0] && item.Key == searchingFor[1])
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
