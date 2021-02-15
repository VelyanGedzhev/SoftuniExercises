using System;
using Microsoft.Data.SqlClient;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=SoftUni"))
            {
                connection.Open();

                //SqlCommand sqlCommand = new SqlCommand("UPDATE Employees SET " +
                //    "Salary = Salary * 0.12", connection);
                //var rowsAffected = sqlCommand.ExecuteNonQuery();

                //SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                //var rowsAffected = (int)sqlCommand.ExecuteScalar();

                //SqlCommand sqlCommand = new SqlCommand("SELECT SUM(Salary) FROM Employees", connection);
                //var rowsAffected = (decimal)sqlCommand.ExecuteScalar();

                //Console.WriteLine(rowsAffected);

                SqlCommand sqlCommand = new SqlCommand("SELECT TOP(7) [FirstName] + ' ' + [LastName] AS [FullName] FROM Employees ORDER BY [FirstName]", connection);

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine(sqlDataReader["FullName"]);
                    }
                }  
            }
        }
    }
}
