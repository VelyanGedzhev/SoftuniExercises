using Microsoft.Data.SqlClient;
using System;

namespace IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            int id = int.Parse(Console.ReadLine());

            //string storedProcedure = @"CREATE PROC usp_GetOlder @id INT AS
            //                                UPDATE Minions
            //                                   SET Age += 1
            //                                 WHERE Id = @id";

            //using var procCommand = new SqlCommand(storedProcedure, connection);
            //procCommand.ExecuteNonQuery();

            string query = "EXEC usp_GetOlder @id";

            using var sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();

            string selectQuery = "SELECT Name, Age FROM Minions WHERE Id = @Id";

            using var selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@id", id);

            using var reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]} years old");
            }
        }
    }
}
