using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {

            var regexName = new Regex(@"([A-Za-z])");
            var regexKM = new Regex(@"\d");

            string[] inputNames = Console.ReadLine()
                .Split(", ")
                .ToArray();

            var participants = new SortedDictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of race")
                {
                    break;
                }

                MatchCollection participant = Regex.Matches(input, regexName.ToString());
                MatchCollection kmPerParticipant = Regex.Matches(input, regexKM.ToString());

                string name = string.Empty;
                int km = 0;

                foreach (var i in participant)
                {
                    name += i;
                }

                foreach (var i in kmPerParticipant)
                {
                    km += int.Parse(i.ToString());
                }

                for (int i = 0; i < inputNames.Length; i++)
                {
                    if (name == inputNames[i])
                    {
                        if (participants.ContainsKey(name))
                        {
                            participants.Where(x => x.Value == x.Value + km);
                        }
						
                        else
                        {
                            participants.Add(name, km);
                        }
                    }
                }
            }

            var orderedParticipants = participants.OrderByDescending(x => x.Value).Take(3).ToDictionary(x=> x.Key, x=>x.Value);
            List<string> finalThreePlaces = new List<string>(orderedParticipants.Keys);

            Console.WriteLine($"1st place: {finalThreePlaces[0]}");
            Console.WriteLine($"2nd place: {finalThreePlaces[1]}");
            Console.WriteLine($"3rd place: {finalThreePlaces[2]}");
        }
    }
}
