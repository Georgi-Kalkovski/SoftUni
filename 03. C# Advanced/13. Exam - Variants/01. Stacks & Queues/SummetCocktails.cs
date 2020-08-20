using System;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    class SummetCocktails
    {
        static void Main(string[] args)
        {
            int[] basktetsWithIngredients = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] freshnessValues = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> baskets = new Queue<int>();
            Stack<int> freshness = new Stack<int>();

            for (int i = 0; i < basktetsWithIngredients.Length; i++)
            {
                baskets.Enqueue(basktetsWithIngredients[i]);
            }

            for (int i = 0; i < freshnessValues.Length; i++)
            {
                freshness.Push(freshnessValues[i]);
            }

            Dictionary<string, int> cocktailsValues = new Dictionary<string, int>();

            cocktailsValues.Add("Mimosa", 150);
            cocktailsValues.Add("Daiquiri", 250);
            cocktailsValues.Add("Sunshine", 300);
            cocktailsValues.Add("Mojito", 400);

            Dictionary<string, int> readyCocktails = new Dictionary<string, int>();

            readyCocktails.Add("Mimosa", 0);
            readyCocktails.Add("Daiquiri", 0);
            readyCocktails.Add("Sunshine", 0);
            readyCocktails.Add("Mojito", 0);

            while (baskets.Count > 0 && freshness.Count > 0)
            {
                int igredients = baskets.Peek();
                int fresh = freshness.Peek();

                if (igredients == 0)
                {
                    baskets.Dequeue();
                    continue;
                }

                int cocktail = igredients * fresh;

                bool isCocktail = cocktailsValues.Any(x => x.Value == cocktail);

                if (isCocktail)
                {
                    foreach (var pair in cocktailsValues)
                    {
                        if (pair.Value == cocktail)
                        {
                            string cocktailName = pair.Key;
                            readyCocktails[cocktailName]++;
                        }
                    }

                    baskets.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    baskets.Enqueue(baskets.Dequeue() + 5);
                    freshness.Pop();
                }
            }

            var areAllCocktailsReady = readyCocktails.All(x => x.Value != 0);

            if (areAllCocktailsReady)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
                if (baskets.Count > 0)
                {
                    Console.WriteLine($"Ingredients left: {baskets.Sum()}");
                }
            }

            foreach (var readyCocktail in readyCocktails.OrderBy(x => x.Key))
            {
                if (readyCocktail.Value != 0)
                {
                    Console.WriteLine($"# {readyCocktail.Key} --> {readyCocktail.Value}");

                }
            }
        }
    }
}
