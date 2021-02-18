using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace IncreaseMinionAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            int[] minionsId = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string updateMinions = @" UPDATE Minions
                             SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                             WHERE Id = @Id";

            foreach (var id in minionsId)
            {
                using var sqlCommand = new SqlCommand(updateMinions, connection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                var name = sqlCommand.ExecuteNonQuery();
            }

            var selectMinions = "SELECT Name, Age FROM Minions";

            using var selectCommand = new SqlCommand(selectMinions, connection);

            using var reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");
            }
        }
    }
}
