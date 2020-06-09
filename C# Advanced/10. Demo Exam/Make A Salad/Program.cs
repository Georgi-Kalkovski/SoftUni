using System;
using System.Collections.Generic;
using System.Linq;

namespace Make_A_Salad
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vegetables = Console.ReadLine()
                .Split();

            Queue<string> vegetablesQueue = new Queue<string>(vegetables);

            int[] calorieValuesOfTheSalads = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> saladCaloriesStack = new Stack<int>(calorieValuesOfTheSalads);

            List<int> saladsMade = new List<int>();

            int tomatoCal = 80;
            int carrotCal = 136;
            int lettuceCal = 109;
            int potatoCal = 215;
            int currentSalad = 0;
            int currentVegetable = 0;

            while (true)
            {
                if (vegetablesQueue.Count == 0 || saladCaloriesStack.Count == 0)
                {
                    break;
                }
                if (currentSalad == 0)
                {
                    currentSalad = saladCaloriesStack.Peek();
                }
                switch (vegetablesQueue.Peek())
                {
                    case "tomato":
                        currentVegetable = tomatoCal;
                        break;
                    case "carrot":
                        currentVegetable = carrotCal;
                        break;
                    case "lettuce":
                        currentVegetable = lettuceCal;
                        break;
                    case "potato":
                        currentVegetable = potatoCal;
                        break;
                }
                vegetablesQueue.Dequeue();

                if (currentSalad > 0)
                {
                    currentSalad -= currentVegetable;
                    if (currentSalad <= 0 || vegetablesQueue.Count == 0 || saladCaloriesStack.Count == 0)
                    {
                        currentSalad = 0;
                        saladsMade.Add(saladCaloriesStack.Pop());
                        if (vegetablesQueue.Count == 0)
                        {
                            Console.WriteLine(string.Join(" ", saladsMade));
                            Console.WriteLine(string.Join(" ", saladCaloriesStack));
                            return;
                        }
                        if (saladCaloriesStack.Count == 0)
                        {
                            Console.WriteLine(string.Join(" ", saladsMade));
                            Console.WriteLine(string.Join(" ", vegetablesQueue));
                            return;
                        }
                    }
                }
            }
        }
    }
}
