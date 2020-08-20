using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Summer_Cocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredients = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var freshnessLvl = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queueOfIngredients = new Queue<int>(ingredients);
            Stack<int> stackOfFreshnessLvl = new Stack<int>(freshnessLvl);

            var mimosaCount = 0;
            var daiquiriCount = 0;
            var sunshineCount = 0;
            var mojitoCount = 0;

            var mixing = 0;
            var oneOfEachType = false;

            while (queueOfIngredients.Count > 0 && stackOfFreshnessLvl.Count > 0)
            {

                if (queueOfIngredients.Peek() == 0)
                {
                    queueOfIngredients.Dequeue();
                    continue;
                }

                if (queueOfIngredients.Count < 1 || stackOfFreshnessLvl.Count < 1)
                {
                    break;
                }

                mixing = queueOfIngredients.Peek() * stackOfFreshnessLvl.Peek();

                switch (mixing)
                {
                    case 150:
                        {
                            mimosaCount++;
                            queueOfIngredients.Dequeue();
                            stackOfFreshnessLvl.Pop();
                        }
                        break;

                    case 250:
                        {
                            daiquiriCount++;
                            queueOfIngredients.Dequeue();
                            stackOfFreshnessLvl.Pop();
                        }
                        break;

                    case 300:
                        {
                            sunshineCount++;
                            queueOfIngredients.Dequeue();
                            stackOfFreshnessLvl.Pop();
                        }
                        break;

                    case 400:
                        mojitoCount++;
                        queueOfIngredients.Dequeue();
                        stackOfFreshnessLvl.Pop();
                        break;

                    default:
                        {
                            queueOfIngredients.Enqueue(queueOfIngredients.Dequeue() + 5);
                            stackOfFreshnessLvl.Pop();
                        }
                        break;
                }

                if (mimosaCount > 0 && daiquiriCount > 0 && sunshineCount > 0 && mojitoCount > 0)
                {
                    oneOfEachType = true;
                }
            }

            if (oneOfEachType)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }

            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
                if (queueOfIngredients.Count > 0)
                {
                    Console.WriteLine($"Ingredients left: {queueOfIngredients.Sum()}");
                }
            }

            if (daiquiriCount > 0) Console.WriteLine($" # Daiquiri --> {daiquiriCount}");
            if (mimosaCount > 0) Console.WriteLine($" # Mimosa --> {mimosaCount}");
            if (mojitoCount > 0) Console.WriteLine($" # Mojito --> {mojitoCount}");
            if (sunshineCount > 0) Console.WriteLine($" # Sunshine --> {sunshineCount}");
        }
    }
}
