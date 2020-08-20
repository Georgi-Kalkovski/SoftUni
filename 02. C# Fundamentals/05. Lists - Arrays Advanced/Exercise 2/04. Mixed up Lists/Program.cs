using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Mixed_up_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> inputTwo = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> rule = new List<int>();
            List<int> maxList = new List<int>();
            List<int> mixedList = new List<int>();
			
            if (inputOne.Count > inputTwo.Count)
            {
                maxList = inputOne;
            }
			
            else
            {
                maxList = inputTwo;
                maxList.Reverse();
            }
			
            for (int i = maxList.Count - 2; i < maxList.Count; i++)
            {
                rule.Add(maxList[i]);
            }
			
            rule.Sort();
			
            if (inputOne.Count > inputTwo.Count)
            {
                inputOne.RemoveRange(inputOne.Count - 2, 2);
                inputTwo.Reverse();
            }
			
            else
            {
                inputTwo.RemoveRange(inputTwo.Count - 2, 2);
                inputTwo.Reverse();
            }
			
            for (int i = 0; i < inputOne.Count; i++)
            {
                mixedList.Add(inputOne[i]);
                mixedList.Add(inputTwo[i]);
            }
			
            List<int> output = mixedList.FindAll(x => x > rule[0] && x < rule[1]);
            output.Sort();
            Console.WriteLine(string.Join(" ", output));
        }
    }
}