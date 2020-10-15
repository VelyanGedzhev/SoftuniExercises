using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace _5._TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int teamsCount = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < teamsCount; i++)
            {
                string[] info = Console.ReadLine()
                        .Split("-")
                        .ToArray();

                string creator = info[0];
                string name = info[1];

                if (teams.Any(x => x.TeamName == name))
                {
                    Console.WriteLine($"Team {name} was already created!");
                    continue;
                }
                if (teams.Any(x => x.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }
                Team team = new Team(name, creator);
                teams.Add(team);
                Console.WriteLine($"Team {name} has been created by {creator}!");
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
           
                 string[] info = command
                     .Split("->")
                     .ToArray();

                 string person = info[0];
                 string name = info[1];

                if (!(teams.Any(x => x.TeamName == name)))
                {
                    Console.WriteLine($"Team {name} does not exist!");
                    continue;
                }
                if (teams.Any(x => x.TeamMembers.Contains(person)) 
                    || teams.Any(x => x.Creator == person && x.TeamName == name))
                {
                    Console.WriteLine($"Member {person} cannot join team {name}!");
                    continue;
                }
                int index = teams.FindIndex(x => x.TeamName == name);
                teams[index].TeamMembers.Add(person);
            }

            var teamsToBeDisbanded = teams
            .FindAll(x => x.TeamMembers.Count == 0)
            .OrderBy(x => x.TeamName)
            .ToList();

            foreach (var team in teams.Where(x => x.TeamMembers.Count > 0)
                .OrderByDescending(x => x.TeamMembers.Count)
                .ThenBy(x => x.TeamName))
            {
                Console.WriteLine(team.ToString());
            }

            Console.WriteLine("Teams to disband:");
            foreach (var team in teamsToBeDisbanded)
            {
                Console.WriteLine(team.TeamName);
            }
            //var teamsToDisband = teams
            //    .FindAll(x => x.TeamMembers.Count == 0)
            //    .OrderBy(x =>x.TeamName)
            //    .ToList();

            //var validTeams = teams
            //    .FindAll(x => x.TeamMembers.Count > 0)
            //    .OrderBy(x => x.TeamName)
            //    .ToList();

            //Console.WriteLine(String.Join(Environment.NewLine, 
            //    validTeams.OrderByDescending(x => x.TeamMembers.Count)
            //    .ThenBy(x => x.TeamName)));

            //Console.WriteLine("Teams to disband:");

            //foreach (var item in teamsToDisband)
            //{
            //    Console.WriteLine(item.TeamName);
            //}

        }
    }
    public class Team
    {
        public string Creator { get; set; }
        public string TeamName { get; set; }
        public List<string> TeamMembers;

        public Team(string name, string creator)
        {
            TeamMembers = new List<string>();
            Creator = creator;
            TeamName = name;
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine(TeamName);
            text.AppendLine("- " + Creator);

            foreach (var item in TeamMembers)
            {
                text.AppendLine("-- " + item);
            }
            return text.ToString().TrimEnd();
        }
    }
}
