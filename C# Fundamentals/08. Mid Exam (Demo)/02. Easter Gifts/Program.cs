using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfGifts = Console.ReadLine()
                .Split()
                .ToList();

            while (true)
            {
                List<string> input = Console.ReadLine()
                    .Split()
                    .ToList();

                if (input[0] == "No" && input[1] == "Money")
                {
                    listOfGifts.RemoveAll(text => text == "None");
                    Console.WriteLine(string.Join(" ", listOfGifts));
                    return;
                }

                if (input[0] == "OutOfStock")
                {
                    for (int i = 0; i < listOfGifts.Count; i++)
                    {
                        if (listOfGifts[i].Contains(input[1]))
                        {
                            listOfGifts.Remove(input[1]);
                            listOfGifts.Insert(i, "None");
                            continue;
                        }
                    }
					
                    continue;
                }
				
                if (input[0] == "Required")
                {
                    if (int.Parse(input[2]) == listOfGifts.Count-1)
                    {
                        listOfGifts.RemoveAt(listOfGifts.Count-1);
                        listOfGifts.Add(input[1]);
                        continue;
                    }
					
                    if (int.Parse(input[2]) >= listOfGifts.Count || int.Parse(input[2]) < 0)
                    {
                        continue;
                    }
					
                    listOfGifts.RemoveAt(int.Parse(input[2]));
                    listOfGifts.Insert(int.Parse(input[2]), input[1]);
                    continue;
                }
				
                if (input[0] == "JustInCase")
                {
                    listOfGifts.RemoveAt(listOfGifts.Count - 1);
                    listOfGifts.Add(input[1]);
                    continue;
                }
            }

            
        }
    }
}
