using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace ado.netExercise
{
    public class Program
    {
        const string connectionString = "Server=.;Integrated Security=true;Database=MinionsDB";
        public static void Main(string[] args)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                //create DB
                //GetInitialSetup(connection);

                //GetVillainNamesAndMinionsCount(connection);

                //SqlCommand command = GetMinionNames(connection);

                //AddMinion(connection);
            }
        }

        private static void AddMinion(SqlConnection connection)
        {
            string[] minionArgs = Console.ReadLine()
                                    .Split(' ');

            string[] villainArgs = Console.ReadLine()
                    .Split(' ');

            string minionName = minionArgs[1];
            int age = int.Parse(minionArgs[2]);
            string town = minionArgs[3];

            int? townId = GetTownId(connection, town);

            if (townId == null)
            {
                string createTownQuery = "INSERT INTO Towns (Name) VALUES (@townName)";

                using var createTown = new SqlCommand(createTownQuery, connection);
                createTown.Parameters.AddWithValue("@townName", town);
                createTown.ExecuteNonQuery();

                townId = GetTownId(connection, town);

                Console.WriteLine($"Town {town} was added to the database.");
            }

            string villainName = villainArgs[1];
            int? villainId = GetVillainId(connection, villainName);

            if (villainId == null)
            {
                string createVillainQuery = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

                using var createVillain = new SqlCommand(createVillainQuery, connection);
                createVillain.Parameters.AddWithValue("@villainName", villainName);
                createVillain.ExecuteNonQuery();

                villainId = GetVillainId(connection, villainName);

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            CreateMinion(connection, minionName, age, townId);
            var minionId = GetMinionId(connection, minionName);

            InsertMinionVillain(connection, villainId, minionId);

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static void InsertMinionVillain(SqlConnection connection, int? villainId, int? minionId)
        {
            var insertIntoMinionVillain = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            var sqlCommand = new SqlCommand(insertIntoMinionVillain, connection);
            sqlCommand.Parameters.AddWithValue("@villainId", villainId);
            sqlCommand.Parameters.AddWithValue("@minionId", minionId);
            sqlCommand.ExecuteNonQuery();
        }

        private static int? GetMinionId(SqlConnection connection, string minionName)
        {
            var minionIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";
            var getMinion = new SqlCommand(minionIdQuery, connection);
            getMinion.Parameters.AddWithValue("@Name", minionName);
            var minionId = getMinion.ExecuteScalar();
            return (int?)minionId;
        }

        private static void CreateMinion(SqlConnection connection, string minionName, int age, int? townId)
        {
            string createMinionQuery = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
            using var createMinion = new SqlCommand(createMinionQuery, connection);
            createMinion.Parameters.AddWithValue("@name", minionName);
            createMinion.Parameters.AddWithValue("@age", age);
            createMinion.Parameters.AddWithValue("@townId", townId);
            createMinion.ExecuteNonQuery();
        }

        private static int? GetVillainId(SqlConnection connection, string villainName)
        {
            string villainIdQuery = "SELECT Id FROM Villains WHERE Name = @Name";
            using var sqlCommand = new SqlCommand(villainIdQuery, connection);
            sqlCommand.Parameters.AddWithValue("@Name", villainName);
            var villainId = sqlCommand.ExecuteScalar();

            return (int?)villainId;
        }

        private static int? GetTownId(SqlConnection connection, string town)
        {
            string townIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";
            using var sqlCommand = new SqlCommand(townIdQuery, connection);
            sqlCommand.Parameters.AddWithValue("@townName", town);
            var townId = sqlCommand.ExecuteScalar();

            return (int?)townId;
        }

        private static SqlCommand GetMinionNames(SqlConnection connection)
        {
            int villainId = int.Parse(Console.ReadLine());
            string villainNameQuery = $"SELECT Name FROM Villains WHERE Id = @Id";
            var command = new SqlCommand(villainNameQuery, connection);
            command.Parameters.AddWithValue("@Id", villainId);
            var result = command.ExecuteScalar();

            string minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum, m.Name,  m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

            if (result == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                Console.WriteLine($"Villain: {result}");

                using (var minionCommand = new SqlCommand(minionsQuery, connection))
                {
                    minionCommand.Parameters.AddWithValue("@Id", villainId);

                    using (var reader = minionCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
                        }
                    }
                }
            }

            return command;
        }

        private static void GetVillainNamesAndMinionsCount(SqlConnection connection)
        {
            string query = @"SELECT v.Name AS [Name], COUNT(mv.MinionId) AS [Count]
	                                FROM Villains AS v
	                                JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
	                                GROUP BY v.Id, v.Name
	                                HAVING COUNT(mv.MinionId) >= 3
	                                ORDER BY [Count] DESC";

            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var currentName = reader[0];
                        var currentCount = reader[1];

                        Console.WriteLine($"{currentName} - {currentCount}");
                    }
                }
            }
        }

        private static void GetInitialSetup(SqlConnection connection)
        {
            string createDB = "CREATE DATABASE MinionsDB";
            ExecuteNonQuery(connection, createDB);

            var createTableArgs = GetCreateTableStatements();

            foreach (var query in createTableArgs)
            {
                ExecuteNonQuery(connection, query);
            }

            var insertArgs = GetInsertDataStatements();

            foreach (var query in insertArgs)
            {
                ExecuteNonQuery(connection, query);
            }
        }

        private static void ExecuteNonQuery(SqlConnection connection, string createDB)
        {
            using var command = new SqlCommand(createDB, connection);
            var result = command.ExecuteNonQuery();
        }

        private static string[] GetCreateTableStatements()
        {
            var result = new string[]
            {
                "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))",
                "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))",
                "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))"
            };

            return result;
        }

        private static string[] GetInsertDataStatements()
        {
            var result = new string[]
            {
                "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')",
                "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)",
                "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)",
                "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')",
                "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)",
                "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)"
            };

            return result;
        }
    }
}
