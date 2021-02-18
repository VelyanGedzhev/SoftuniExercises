using Microsoft.Data.SqlClient;
using System;

namespace RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.;Integrated Security=true;Database=MinionsDB";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string villainNameQuery = "SELECT Name FROM Villains WHERE Id = @villainId";
                int villainId = int.Parse(Console.ReadLine());

                using (var sqlCommand = new SqlCommand(villainNameQuery, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@villainId", villainId);
                    var name = sqlCommand.ExecuteScalar() as string;

                    if (name == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }

                    var deleteMinionsQuery = @"DELETE FROM MinionsVillains 
                                                 WHERE VillainId = @villainId";

                    var deteleVillainsQuery = @"DELETE FROM Villains
                                                 WHERE Id = @villainId";

                    using var sqlDeleteMV = new SqlCommand(deleteMinionsQuery, connection);
                    sqlDeleteMV.Parameters.AddWithValue(@"villainId", villainId);
                    var affectedRows = sqlDeleteMV.ExecuteNonQuery();

                    using var sqlDeleteVillian = new SqlCommand(deteleVillainsQuery, connection);
                    sqlDeleteVillian.Parameters.AddWithValue(@"villainId", villainId);
                    sqlDeleteVillian.ExecuteNonQuery();

                    Console.WriteLine($"{name} was deleted.");
                    Console.WriteLine($"{affectedRows} minions were released.");
                }
            }

                

            

        }
    }
}
