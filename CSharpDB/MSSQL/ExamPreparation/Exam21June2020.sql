--Section 1.DDL
--1. Database design

CREATE DATABASE TripService
USE TripService

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15,2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(15,2) NOT NULL,
	Type NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,
	CHECK(BookDate < ArrivalDate),
	CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
	Email NVARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE AccountsTrips
(
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
	Luggage INT CHECK(Luggage >= 0) NOT NULL,
	CONSTRAINT PK_AccountsTrips PRIMARY KEY(AccountId, TripId)
)

--Section 2. DML
--2.Insert
INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email) VALUES
('John',	'Smith',	'Smith',	34,	'1975-07-21',	'j_smith@gmail.com'),
('Gosho',	NULL,	'Petrov',	11,	'1978-05-16',	'g_petrov@gmail.com'),
('Ivan',	'Petrovich',	'Pavlov',	59,	'1849-09-26',	'i_pavlov@softuni.bg'),
('Friedrich',	'Wilhelm',	'Nietzsche',	2,	'1844-10-15',	'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate) VALUES
(101, '2015-04-12',	'2015-04-14','2015-04-20',	'2015-02-02'),
(102, '2015-07-07',	'2015-07-15','2015-07-22',	'2015-04-29'),
(103, '2013-07-17',	'2013-07-23','2013-07-24',	NULL),
(104, '2012-03-17',	'2012-03-31','2012-04-01',	'2012-01-10'),
(109, '2017-08-07',	'2017-08-28','2017-08-29',	NULL)

--3.Update
UPDATE Rooms
	SET Price = Price + Price * 0.14
	WHERE HotelId IN (5, 7, 9)

--4.Delete
DELETE FROM AccountsTrips
	WHERE AccountId = 47

--Section 3. Querying
--5.EEE-mails
SELECT 
		a.FirstName,
		a.LastName,
		FORMAT(a.BirthDate, 'MM-dd-yyyy') AS BirthDate,
		c.Name AS Hometown,
		a.Email
	FROM Accounts AS a
	JOIN Cities AS c ON c.Id = a.CityId
	WHERE Email LIKE ('e%')
	ORDER BY c.Name

--6.City statistics
SELECT 
		c.Name AS City,
		COUNT(h.CityId) AS Hotels
	FROM Hotels AS h
	JOIN Cities AS c ON c.Id = h.CityId
	GROUP BY c.Name
	ORDER BY Hotels DESC, City

--Another solution
--SELECT 
--		[Name] AS City,
--		(SELECT COUNT(*) FROM Hotels AS h WHERE h.CityId = c.Id) AS Hotels
--	FROM Cities AS c
--	WHERE (SELECT COUNT(*) FROM Hotels AS h WHERE h.CityId = c.Id) > 0
--	ORDER BY Hotels DESC, City

--7.Longest and Shortest Trips
SELECT 
		[at].AccountId,
		CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
		MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
		MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
	FROM AccountsTrips AS [at]
	LEFT JOIN Accounts AS a ON a.Id = [at].AccountId
	LEFT JOIN Trips AS t ON t.Id = [at].TripId
	WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
	GROUP BY [at].AccountId, FirstName, LastName
	ORDER BY LongestTrip DESC, ShortestTrip

--8.Metropolis
SELECT TOP(10)
		c.Id,
		c.Name,
		c.CountryCode,
		COUNT(*) AS Accounts
	FROM Cities AS c
	JOIN Accounts AS a ON a.CityId = c.Id
	GROUP BY c.Id, c.Name, c.CountryCode
	ORDER BY Accounts DESC

--9.Romantic Getaways
SELECT 
		at.AccountId, 
		a.Email, 
		c.Name,
		COUNT(*) AS Trips
	FROM AccountsTrips AS at
	JOIN Accounts AS a ON at.AccountId = a.Id
	JOIN Cities AS c ON c.Id = a.CityId
	JOIN Trips AS t ON t.Id = at.TripId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities c2 ON c2.Id = h.CityId
	WHERE c2.Id = c.Id
	GROUP BY at.AccountId, a.Email, c.Name
	ORDER BY Trips DESC, at.AccountId

--10.GDPR Violation
SELECT 
		t.Id,
		a.FirstName + ' ' + ISNULL(a.MiddleName + ' ', '' ) + a.LastName AS FullName,
		ac.Name AS [From],
		hc.Name AS [To],
		CASE 
			WHEN t.CancelDate IS NULL THEN CONVERT(NVARCHAR,DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) + ' days'
			ELSE 'Canceled'
			END AS Duration
	FROM AccountsTrips AS at
	JOIN Accounts AS a ON a.Id = at.AccountId
	JOIN Cities AS ac ON ac.Id = a.CityId
	JOIN Trips AS t ON t.Id = at.TripId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS hc ON hc.Id = h.CityId
	ORDER BY FullName, TripId
	
--11. Available Room
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @Result VARCHAR(MAX) = (SELECT TOP(1)
		'Room ' + CONVERT(VARCHAR, r.Id)+ ': ' +  r.Type + ' (' +
		CONVERT(VARCHAR, r.Beds) + ' beds) - $' + 
		CONVERT(VARCHAR, (h.BaseRate + r.Price) * @People)
	FROM Rooms AS r
	JOIN Hotels AS h ON h.Id = r.HotelId
	WHERE r.Beds >= @People AND r.HotelId = @HotelId AND 
		NOT EXISTS(SELECT * FROM Trips AS t 
					WHERE  t.RoomId = r.Id AND
							t.CancelDate IS NULL AND
							@Date BETWEEN t.ArrivalDate AND t.ReturnDate)
	ORDER BY (h.BaseRate + r.Price) * @People DESC)

	IF(@Result IS NULL)
		RETURN 'No rooms available'

	RETURN @Result
END
GO

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

--12. Switch Room
CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @TripHotelId INT = (SELECT r.HotelId FROM Trips AS t
									JOIN Rooms AS r ON t.RoomId = r.Id
									WHERE t.Id = @TripId)
	
	DECLARE @TargetRoomHotelId INT = (SELECT HotelId FROM Rooms
										WHERE Id = @TargetRoomId)

	IF(@TripHotelId != @TargetRoomHotelId)
		THROW 50001, 'Target room is in another hotel!', 1

	DECLARE @TripPeopleCount INT = (SELECT COUNT(*) FROM AccountsTrips
									WHERE TripId = @TripId)
	DECLARE @TargetRoomBeds INT = (SELECT Beds FROM Rooms
									WHERE Id = @TargetRoomId)

	IF(@TripPeopleCount > @TargetRoomBeds)
		THROW 50002, 'Not enough beds in target room!', 1

	UPDATE Trips 
		SET RoomId = @TargetRoomId WHERE Id = @TripId

GO

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

EXEC usp_SwitchRoom 10, 7
SELECT RoomId FROM Trips WHERE Id = 10

EXEC usp_SwitchRoom 10, 8
SELECT RoomId FROM Trips WHERE Id = 10
