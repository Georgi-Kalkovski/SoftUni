using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem05TeamworkProjects
{
    class Team
    {
        public string TeamName;
        public string Creator;
        public List<string> Members = new List<string>();
    }
	
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 1; i <= numberOfTeams; i++)
            {
                string[] line = Console.ReadLine().Split('-');

                var currentTeam = new Team();

                string creator = line[0];
                string teamName = line[1];

                currentTeam.Creator = creator;
                currentTeam.TeamName = teamName;

                if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(x => x.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                teams.Add(currentTeam);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            while (true)
            {
                string currentCommand = Console.ReadLine();

                if (currentCommand == "end of assignment")
                {
                    break;
                }

                string[] line = currentCommand.Split("->");

                string user = line[0];
                string team = line[1];

                if (!teams.Any(x => x.TeamName == team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                    continue;
                }

                if (teams.Any(x => x.Creator == user) || teams.Any(x => x.Members.Contains(user)))
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                    continue;
                }

                if (teams.Any(x => x.TeamName == team))
                {
                    var existingTeam = teams.First(x => x.TeamName == team);

                    existingTeam.Members.Add(user);
                }
            }

            var teamsDisband = teams.Where(x => x.Members.Count == 0).Select(x => x.TeamName).ToList();

            foreach (var team in teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName))
            {
                if (team.Members.Count == 0)
                {
                    continue;
                }

                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");

                foreach (var name in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {name}");
                }
            }

            Console.WriteLine("Teams to disband:");
			
            foreach (var item in teamsDisband.OrderBy(x => x))
            {
                Console.WriteLine(item);
            }
        }
    }
}