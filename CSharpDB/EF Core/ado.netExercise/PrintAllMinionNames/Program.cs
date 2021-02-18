using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace PrintAllMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var minionsQuery = "SELECT Name FROM Minions";

            using var selectCommand = new SqlCommand(minionsQuery, connection);

            using var reader = selectCommand.ExecuteReader();
            List<string> minions = new List<string>();

            while (reader.Read())
            {
                minions.Add(reader[0] as string);
            }

            int counter = 0;

            for (int i = 0; i < minions.Count / 2; i++)
            {
                Console.WriteLine(minions[0 + counter]);
                Console.WriteLine(minions[minions.Count - 1 - counter]);
                counter++;

                if (minions.Count % 2 != 0)
                {
                    Console.WriteLine(minions[minions.Count / 2]);
                }
            }
        }
    }
}
