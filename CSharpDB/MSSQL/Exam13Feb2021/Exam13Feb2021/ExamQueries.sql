CREATE DATABASE Bitbucket
USE Bitbucket

--Section 1. DDL
--1. Database design

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(30) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	CONSTRAINT PK_RepositoriesUsers PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL(15,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)
--Section 2. DML
--2. Insert
INSERT INTO Files ([Name], Size, ParentId, CommitId) VALUES
('Trade.idk',	2598.0,	1,	1),
('menu.net',	9238.31,	2,	2),
('Administrate.soshy',	1246.93,	3,	3),
('Controller.php',	7353.15,	4,	4),
('Find.java',	9957.86,	5,	5),
('Controller.json',	14034.87,	3,	6),
('Operate.xix',	7662.92,	7,	7)

INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId) VALUES
('Critical Problem with HomeController.cs file', 'open',	1,	4),
('Typo fix in Judge.html', '	open',	4,	3),
('Implement documentation for UsersService.cs', 'closed',	8,	2),
('Unreachable code in Index.cs', 'open',	9,	8)

--3. Update
UPDATE Issues
	SET IssueStatus = 'closed'
	WHERE AssigneeId = 6

--4. Delete
DELETE FROM Issues
	WHERE RepositoryId = (SELECT Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM RepositoriesContributors
	WHERE RepositoryId = (SELECT Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')

--DELETE FROM Repositories
--	WHERE [Name] = 'Softuni-Teamwork'

--Section 3. Querying
--5. Commits
SELECT 
		Id,
		[Message],
		RepositoryId,
		ContributorId
	FROM Commits
	ORDER BY Id, [Message], RepositoryId, ContributorId

--6. Front-end
SELECT	
		f.Id,
		f.[Name],
		f.Size
	FROM Files AS f
	WHERE f.Size > 1000 AND f.Name LIKE '%html%'
	ORDER BY f.Size DESC, f.Id, f.Name

--7. Issue Assignment
SELECT 
		i.Id,
		u.Username + ' : ' + i.Title AS IssueAssignee
	FROM Issues AS i
	JOIN Users AS u ON i.AssigneeId = u.Id
	ORDER BY i.Id DESC, i.AssigneeId

--8. Single Files
SELECT 
		f.Id,
		f.Name,
		CONVERT(VARCHAR,f.Size) + 'KB' AS Size
	FROM Files AS f
	LEFT JOIN Files AS fi ON f.Id = fi.ParentId
	WHERE fi.Id IS NULL
	ORDER BY f.Id, f.Name, f.Size DESC

--9. Commits in Repositories
SELECT TOP(5)
		r.Id,
		r.Name,
		COUNT(*) AS Commits
	FROM Repositories AS r
	LEFT JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
	LEFT JOIN Commits AS c ON r.Id = c.RepositoryId
	GROUP BY r.Name, r.Id
	ORDER BY COUNT(*) DESC, r.Id, r.Name

--10. Average Size
SELECT 
		u.Username,
		AVG(f.Size) AS Size
	FROM Users AS u
	JOIN Commits AS c ON u.Id = c.ContributorId
	JOIN Files AS f ON f.CommitId = c.Id
	GROUP BY u.Username
	ORDER BY AVG(f.Size) DESC, u.Username

GO
--Section 4. Programmability (20 pts)
--11. All Users Commits
CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
	BEGIN 
		DECLARE @UserID INT = (SELECT Id FROM Users
				WHERE Username = @username)
		
		DECLARE @CommitsCount INT = 
				(SELECT COUNT(*) FROM Commits as c
				WHERE  c.ContributorId = @UserID)

		RETURN @CommitsCount
	END
GO
SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

GO
--12. Search for Files
CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(5)) 
AS
	BEGIN
		SELECT 
				f.Id,
				f.Name,
				CONVERT(VARCHAR, f.Size)+'KB' AS Size
			FROM Files AS f
			WHERE f.Name LIKE '%.' + @fileExtension
			ORDER BY f.Id, f.Name, f.Size DESC
	END
GO
EXEC usp_SearchForFiles 'txt'

