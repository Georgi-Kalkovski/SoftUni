using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Spaceship_Crafting
{
    class Program
    {
        static void Main(string[] args)
        {
            var chemicalLiquids = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var physicalItems = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> queueOfChemicalLiquids = new Queue<int>(chemicalLiquids);
            Stack<int> stackOfPhysicalItems = new Stack<int>(physicalItems);

            int glassMade = 0;
            int aluminiumMade = 0;
            int lithiumMade = 0;
            int carbonFiberMade = 0;

            while (queueOfChemicalLiquids.Count != 0
                  || stackOfPhysicalItems.Count != 0)
            {
                if (queueOfChemicalLiquids.Count == 0
                  || stackOfPhysicalItems.Count == 0)
                {
                    break;
                }

                int currentSum = queueOfChemicalLiquids.Peek() + stackOfPhysicalItems.Peek();

                switch (currentSum)
                {
                    case 25:
                        {
                            glassMade++;
                            queueOfChemicalLiquids.Dequeue();
                            stackOfPhysicalItems.Pop();
                        }
                        break;

                    case 50:
                        {
                            aluminiumMade++;
                            queueOfChemicalLiquids.Dequeue();
                            stackOfPhysicalItems.Pop();
                        }
                        break;

                    case 75:
                        {
                            lithiumMade++;
                            queueOfChemicalLiquids.Dequeue();
                            stackOfPhysicalItems.Pop();
                        }
                        break;

                    case 100:
                        {
                            carbonFiberMade++;
                            queueOfChemicalLiquids.Dequeue();
                            stackOfPhysicalItems.Pop();
                        }
                        break;

                    default:
                        queueOfChemicalLiquids.Dequeue();
                        int currentItem = stackOfPhysicalItems.Pop() + 3;
                        stackOfPhysicalItems.Push(currentItem);
                        break;
                }
            }

            if (glassMade > 0
               && aluminiumMade > 0
               && lithiumMade > 0
               && carbonFiberMade > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }

            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (queueOfChemicalLiquids.Count() == 0)
            {
                Console.WriteLine("Liquids left: none");
            }

            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", queueOfChemicalLiquids)}");
            }

            if (stackOfPhysicalItems.Count() == 0)
            {
                Console.WriteLine("Physical items left: none");
            }

            else
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", stackOfPhysicalItems)}");
            }

            Console.WriteLine($"Aluminium: {aluminiumMade}");
            Console.WriteLine($"Carbon fiber: {carbonFiberMade}");
            Console.WriteLine($"Glass: {glassMade}");
            Console.WriteLine($"Lithium: {lithiumMade}");
        }
    }
}

