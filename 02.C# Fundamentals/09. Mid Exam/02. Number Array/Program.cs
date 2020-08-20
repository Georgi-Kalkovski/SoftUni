using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sumOfNegative = 0;
            int sumOfPositive = 0;
            int sumAll = 0;

            bool isNegativeUsed = false;
            bool isPositiveUsed = false;
            bool isAllUsed = false;

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();
                
                if (input[0] == "End")
                {
                    break;
                }

                if (input[0] == "Switch")
                {
                    if (list.Contains(int.Parse(input[1])))
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] - 1 == int.Parse(input[1]))
                            {
                                if (list[i] - 1 < 0)
                                {
                                    Math.Abs(list[i]);
                                    break;
                                }
								
                                else
                                {
                                    list[i] *= -1;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (input[0] == "Change")
                {
                    if (list.Contains(int.Parse(input[1])))
                    {
                        continue;
                    }
					
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i == int.Parse(input[1]))
                        {
                            list.Insert(i + 1, int.Parse(input[2]));
                            list.RemoveAt(i);
                            break;
                        }
                    }
                }
                if (input[1] == "Negative")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] < 0)
                        {
                            sumOfNegative += list[i];
                            isNegativeUsed = true;
                            list.Remove(list[i]);
                            i--;
                        }
                    }
                }
				
                if (input[1] == "Positive")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] > -1)
                        {
                            sumOfNegative += list[i];
                            isPositiveUsed = true;
                            list.Remove(list[i]);
                            i--;
                        }
						
                        for (int j = 0; j < list.Count; j++)
                        {
                            if (list[i] < 0)
                            {
                                list.Remove(list[i]);
                                i--;
                            }
                        }
                    }
                }
				
                if (input[1] == "All")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        sumAll += list[i];
                        isAllUsed = true;
                    }
					
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] < 0)
                        {
                            list.Remove(list[i]);
                            i--;
                        }
                    }
                }
            }
            if (isPositiveUsed)
                Console.WriteLine(sumOfPositive);

            if (isNegativeUsed)
                Console.WriteLine(sumOfNegative);

            if (isAllUsed)
                Console.WriteLine(sumAll);

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
