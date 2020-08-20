using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestPass = new Dictionary<string, string>();
            var usernamesPoints = new Dictionary<string, List<CandidateInfo>>();

            AddingContests(contestPass);
            AddingContestAndPointsToCandidates(contestPass, usernamesPoints);
            DeterminatingBestCandidate(usernamesPoints);
            PrintingCandidatesContestsAndPoints(usernamesPoints);
        }

        private static void PrintingCandidatesContestsAndPoints(Dictionary<string, List<CandidateInfo>> usernamesPoints)
        {
            Console.WriteLine("Ranking:");

            foreach (var candidate in usernamesPoints.OrderBy(x => x.Key))
            {
                Console.WriteLine(candidate.Key);

                foreach (var contest in candidate.Value.OrderByDescending(x => x.Points))
                {
                    Console.WriteLine($"#  {contest.Contest} -> {contest.Points}");
                }
            }
        }

        private static void DeterminatingBestCandidate(Dictionary<string, List<CandidateInfo>> usernamesPoints)
        {
            int maxSum = 0;
            string topCandidate = string.Empty;
            foreach (var candidate in usernamesPoints)
            {
                int currentSum = 0;

                foreach (var contest in candidate.Value)
                {
                    currentSum += contest.Points;

                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    topCandidate = candidate.Key;
                }
            }

            Console.WriteLine($"Best candidate is {topCandidate} with total {maxSum} points.");
        }

        private static void AddingContestAndPointsToCandidates(Dictionary<string, string> contestPass, Dictionary<string, List<CandidateInfo>> usernamesPoints)
        {
            string candidateInput = string.Empty;
            while ((candidateInput = Console.ReadLine()) != "end of submissions")
            {
                string[] candidateInputArr = candidateInput.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string contest = candidateInputArr[0];
                string pass = candidateInputArr[1];
                string username = candidateInputArr[2];
                int points = int.Parse(candidateInputArr[3]);

                if (contestPass.ContainsKey(contest) && contestPass[contest] == pass)
                {
                    CandidateInfo newInfo = new CandidateInfo(contest, points);
                    if (!usernamesPoints.ContainsKey(username))
                    {
                        usernamesPoints.Add(username, new List<CandidateInfo>());
                        usernamesPoints[username].Add(newInfo);
                        continue;
                    }

                    if (!usernamesPoints[username].Any(x => x.Contest == contest))
                    {
                        usernamesPoints[username].Add(newInfo);
                    }
                    else
                    {
                        CandidateInfo candidateToCheck = usernamesPoints[username].Find(x => x.Contest == contest);

                        if (candidateToCheck.Points < points)
                        {
                            candidateToCheck.Points = points;
                        }
                    }

                }
            }
        }

        private static void AddingContests(Dictionary<string, string> contestPass)
        {
            string contestsInput = string.Empty;
            while ((contestsInput = Console.ReadLine()) != "end of contests")
            {
                string[] contestsInputArr = contestsInput.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                contestPass.Add(contestsInputArr[0], contestsInputArr[1]);
            }
        }
    }
    class CandidateInfo
    {
        public CandidateInfo(string contest, int points)
        {
            Contest = contest;
            Points = points;
        }
        public string Contest { get; set; }
        public int Points { get; set; }
    }
}