using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {

            var userData = new Dictionary<string, string>();
            var gradesData = new SortedDictionary<string, Dictionary<string, int>>();
            var biggestGrades = new Dictionary<string, List<int>>();

            do
            {
                string[] arr = Console.ReadLine()
                    .Split(":");

                if (arr[0] == "end of contests")
                {
                    break;
                }

                string contest = arr[0];
                string passwordOfContest = arr[1];

                userData.Add(contest, passwordOfContest);
            }
            while (true);

            do
            {
                string[] arr = Console.ReadLine()
                    .Split("=>");

                if (arr[0] == "end of submissions")
                {
                    break;
                }

                string contest = arr[0];
                string password = arr[1];
                string username = arr[2];
                int points = int.Parse(arr[3]);

                if (userData.ContainsKey(contest) &&
                    userData.ContainsValue(password) &&
                    !gradesData.ContainsKey(username))
                {

                    if (!gradesData.ContainsKey(username))
                    {
                        gradesData.Add(username, new Dictionary<string, int>());
                    }

                    gradesData[username].Add(contest, points);
                }

                else if (userData.ContainsKey(contest) &&
                    userData.ContainsValue(password) &&
                    gradesData.ContainsKey(username))
                {

                    if (gradesData[username].ContainsKey(contest) && 
                        gradesData[username][contest] < points)
                    {
                        gradesData[username][contest] = points;
                    }

                    else if (gradesData[username].ContainsKey(contest) && 
                        gradesData[username][contest] > points)
                    {
                        continue;
                    }

                    gradesData[username].Add(contest, points);

                }
            }
            while (true);

            int biggestSum = 0;
            string biggestName = string.Empty;

            foreach (var name in gradesData)
            {
                int currentSum = 0;

                foreach (var grade in gradesData[name.Key])
                {
                    currentSum += grade.Value;

                    if (biggestSum < currentSum)
                    {
                        biggestSum = currentSum;
                        biggestName = name.Key;
                    }
                }
            }

            Console.WriteLine($"Best candidate is {biggestName} with total {biggestSum} points.");
            Console.WriteLine("Ranking: ");

            foreach (var name in gradesData)
            {
                Console.WriteLine(name.Key);

                foreach (var contest in gradesData[name.Key].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
