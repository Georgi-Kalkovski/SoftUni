using System;
using System.Linq;

namespace _03._Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split()
                .ToList();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                if (input[0] == "Add")
                {
                    if (list.Contains(input[1]))
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (int.Parse(input[2]) == i)
                            {
                                list.Insert(int.Parse(input[2]), input[1]);
                            }
                        }
                    }
					
                    else
                    {
                        list.Add(input[1]);
                    }
                }

                if (input[0] == "Remove")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (int.Parse(input[1]) == i)
                        {
                            list.RemoveAt(i);
                        }
                    }
                }

                if (input[0] == "Export")
                {
                    int startIndex = int.Parse(input[1]);

                    for (int i = startIndex; i< startIndex + int.Parse(input[2]); i++)
                    {
                        if (i == list.Count)
                        {
                            break;
                        }
						
                        Console.Write(list[i] + " ");
                    }
					
                    Console.WriteLine();
                }

                if (input[0] == "Print")
                {
                    if (input[1] == "Normal")
                    {
                        Console.Write("Contacts: ");
                        Console.WriteLine(string.Join(" ", list));
                        break;
                    }
					
                    if (input[1] == "Reversed")
                    {
                        list.Reverse();
                        Console.Write("Contacts: ");
                        Console.WriteLine(string.Join(" ", list));
                        break;
                    }
                }
            }
        }
    }
}
