using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                string name = input[0];
                int age = int.Parse(input[1]);

                people.Add(name, age);
            }

            string condition = Console.ReadLine();
            int compareAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            var comparing = CompareAge(condition, compareAge);
            var write = Compare(format);


            foreach (var human in people)
            {
                if (comparing(human.Value))
                {
                    write(human);
                }
            }

        }
        static Func<int, bool> CompareAge(string condition, int compareAge)
        {
            if (condition == "older")
            {
                return x => x >= compareAge;
            }

            return x => x < compareAge;
        }

        static Action<KeyValuePair<string, int>> Compare(string format)
        {
            switch (format)
            {
                case "name": return x => Console.WriteLine(x.Key);
                case "age": return x => Console.WriteLine(x.Value);
                default: return x => Console.WriteLine($"{x.Key} - {x.Value}");
            }
        }
    }
}
