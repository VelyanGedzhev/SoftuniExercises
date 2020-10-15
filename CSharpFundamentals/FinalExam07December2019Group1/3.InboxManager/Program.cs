using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.InboxManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

            while (input != "Statistics")
            {
                string[] command = input.Split("->");
                string userName = command[1];
                if (input.Contains("Add"))
                {
                    if (users.ContainsKey(userName))
                    {
                        Console.WriteLine($"{userName} is already registered");
                    }
                    else
                    {
                        users.Add(userName, new List<string>());
                    }
                }
                else if (input.Contains("Send"))
                {
                    string email = command[2];
                    users[userName].Add(email);
                }
                else if (input.Contains("Delete"))
                {
                    if (users.ContainsKey(userName))
                    {
                        users.Remove(userName);
                    }
                    else
                    {
                        Console.WriteLine($"{userName} not found!");
                    }
                }
                input = Console.ReadLine();
            }
            var sortedUsers = users.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key);
            Console.WriteLine($"Users count: {sortedUsers.Count()}");
            foreach (var user in sortedUsers)
            {
                Console.WriteLine(user.Key);

                foreach (var email in user.Value)
                {
                    Console.WriteLine($" - {email}");
                }
            }
        }
    }
}
