using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command
                    .Split(" -> ")
                    .ToArray();

                string companyName = input[0];
                string id = input[1];

                if (companies.ContainsKey(companyName))
                {
                    if (!companies[companyName].Contains(id))
                    {
                        companies[companyName].Add(id);
                    }
                }
                else
                {
                    companies.Add(companyName, new List<string>());
                    companies[companyName].Add(id);
                }
            }
            Dictionary<string, List<string>> sortedCompanies = companies
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var company in sortedCompanies)
            {
                Console.WriteLine(company.Key);
                foreach (var id in company.Value)
                {
                    Console.WriteLine("-- " + id);
                }
            }
        }
    }
}
