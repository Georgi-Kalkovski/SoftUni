using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class People
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
		
        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int counterOfInputs = 0;
            List<People> listOfPeople = new List<People>();

            while(true)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                if (input[0] == "End")
                {
                    break;
                }

                People people = new People();

                people.Name = input[0];
                people.ID = input[1];
                people.Age = int.Parse(input[2]);

                listOfPeople.Add(people);
                counterOfInputs++;
            }

            for(int i = 0; i < counterOfInputs;i++)
            {
                listOfPeople = listOfPeople.OrderBy(x => x.Age).ToList();
                Console.WriteLine(listOfPeople[i]);
            }
        }
    }
}
