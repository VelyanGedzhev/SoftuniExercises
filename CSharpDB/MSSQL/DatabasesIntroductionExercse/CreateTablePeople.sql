USE Minions

CREATE TABLE People
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(200) NOT NULL,
	Picture IMAGE,
	Height DECIMAL(2),
	[Weight] DEcimal(2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography VARCHAR(MAX),
)
