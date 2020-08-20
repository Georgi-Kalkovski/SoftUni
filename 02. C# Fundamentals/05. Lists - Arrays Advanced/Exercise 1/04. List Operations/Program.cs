using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] order = line.Split();
				
				
				
                switch (order[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(order[1]));
                        break;

                    case "Remove":
                        if (int.Parse(order[1]) < 0 || int.Parse(order[1]) >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
						
                        else
                        {
                            numbers.RemoveAt(int.Parse(order[1]));
                        }
                        break;

                    case "Insert":
                        if (int.Parse(order[2]) >= 0 && int.Parse(order[2]) < numbers.Count)
                        {
                            numbers.Insert(int.Parse(order[2]), int.Parse(order[1]));
                        }
						
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;
                }

                switch (order[1])
                {
                    case "left":
                        ShiftLeft(numbers, int.Parse(order[2]));
                        break;
                    case "right":
                        ShiftRight(numbers, int.Parse(order[2]));
                        break;
                }

                line = Console.ReadLine();
            }
			
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }
        }
		
        static void ShiftLeft(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                numbers.Add(numbers[0]);
                numbers.RemoveAt(0);
            }
        }
		
        static void ShiftRight(List<int> numbers, int count)
        {

            for (int i = 0; i < count; i++)
            {
                numbers.Insert(0, numbers[numbers.Count - 1]);
                numbers.RemoveAt(numbers.Count - 1);
            }
        }
    }
}