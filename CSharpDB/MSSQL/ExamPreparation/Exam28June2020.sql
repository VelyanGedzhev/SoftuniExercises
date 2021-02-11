--Section 1. DDL
--1. Database Design
CREATE DATABASE ColonialJourney 
USE ColonialJourney 

CREATE TABLE Planets
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) UNIQUE NOT NULL,
	BirthDate DATE NOT NULL
)

CREATE TABLE Journeys
(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) CHECK(Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)

CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber CHAR(10) UNIQUE NOT NULL,
	JobDuringJourney VARCHAR(10) CHECK(JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL

)
--Section 2. DML
--2. Insert
INSERT INTO Planets (Name) VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships (Name, Manufacturer, LightSpeedRate) VALUES
('Golf', 'VW',	3),
('WakaWaka', 'Wakanda',	4),
('Falcon9',	'SpaceX',	1),
('Bed', 'Vidolov',	6)

--3. Update
UPDATE Spaceships
	SET LightSpeedRate += 1
	WHERE Id BETWEEN 8 AND 12

--4. Delete	
DELETE FROM TravelCards
	WHERE JourneyId <= 3

DELETE FROM Journeys
	WHERE Id <= 3

--Section 3. Querying
--5. Select all military journeys
SELECT 
		Id,
		FORMAT(JourneyStart, 'dd/MM/yyyy') AS JourneyStart,
		FORMAT(JourneyEnd, 'dd/MM/yyyy') AS JourneyEnd
	FROM Journeys
	WHERE Purpose = 'Military'
	ORDER BY JourneyStart

--6. Select all pilots
SELECT	
		c.Id,
		CONCAT(FirstName, ' ', LastName) AS full_name
	FROM Colonists AS c
	JOIN TravelCards AS tc ON  c.Id = tc.ColonistId
	WHERE JobDuringJourney = 'Pilot'
	ORDER BY c.Id

--7. Count colonists
SELECT COUNT(*) AS Count
	FROM Colonists AS c
	JOIN TravelCards AS tc ON c.Id = tc.ColonistId
	JOIN Journeys AS j ON tc.JourneyId = j.Id
	WHERE j.Purpose = 'Technical' 

--8. Select spaceships with pilots younger than 30 years
SELECT 
		s.Name,
		s.Manufacturer
	FROM Spaceships AS s
	JOIN Journeys AS j ON s.Id = j.SpaceshipId
	JOIN TravelCards AS tc ON j.Id = tc.JourneyId
	JOIN Colonists AS c ON tc.ColonistId = c.Id
	WHERE tc.JobDuringJourney = 'Pilot' AND DATEDIFF(YEAR, c.BirthDate, '2019-01-01') <= 30
	ORDER BY s.Name

--9. Select all planets and their journey count
SELECT 
		p.Name,
		COUNT(*) AS JourneysCount
	FROM Planets AS p
	JOIN Spaceports AS s ON p.Id = s.PlanetId
	JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
	GROUP BY p.Name
	ORDER BY JourneysCount DESC, p.Name

--10. Select Second Oldest Important Colonist
SELECT 
		JobDuringJourney,
		FullName,
		rq.Rank
	FROM(SELECT  
		tc.JobDuringJourney,
		CONCAT(FirstName, ' ', LastName) AS FullName,
		DENSE_RANK() OVER(PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate) AS [Rank]
			FROM Colonists AS c
			JOIN TravelCards AS tc ON c.Id = tc.ColonistId) AS rq
	WHERE Rank = 2

	


