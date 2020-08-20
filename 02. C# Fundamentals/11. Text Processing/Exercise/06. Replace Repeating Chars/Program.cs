using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> list = Console.ReadLine().ToList();
            List<string> newList = new List<string>();
			
            for (int i = 0; i <= list.Count(); i++)
            {
                char firstCh = list[i];
                char secondCh = ' ';
				
                if (i != list.Count()-1)
                {
                    secondCh = list[i + 1];
					
                    if (firstCh != secondCh)
                    {
                        newList.Add(firstCh.ToString());
                    }
                }
				
                else
                {
                    newList.Add(firstCh.ToString());
                    break;
                }
            }
			
            Console.WriteLine(string.Join("", newList));
        }
    }
}
