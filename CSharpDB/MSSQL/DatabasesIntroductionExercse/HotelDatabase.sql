--CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	EmergencyName VARCHAR(90) NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE RoomStatus
(
	RoomStatus BIT NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(20)  NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE BedTypes
(
	BedType VARCHAR(20)  NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(20) NOT NULL,
	BedType VARCHAR(20) NOT NULL,
	Rate INT,
	RoomStatus BIT NOT NULL,
	Notes VARCHAR(MAX)
)


CREATE TABLE Payments
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT  NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(15,2) NOT NULL,
	TaxRate DECIMAL(15,2) NOT NULL,
	TaxAmount DECIMAL(15,2) NOT NULL,
	PaymentTotal DECIMAL(15,2) NOT NULL,
	Notes VARCHAR(MAX)
)


CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT,
	PhoneCharge DECIMAL(15,2),
	Notes VARCHAR(MAX)
)
INSERT INTO Occupancies VALUES
(1, 1, '2021-01-13', 01, 213, 7, NULL, NULL),
(2, 2, '2021-01-13', 02, 214, NULL, 17.23, NULL),
(3, 3, '2021-01-13', 03, 215, NULL, NULL, NULL)

INSERT INTO Employees (Id, FirstName, LastName, Title, Notes) VALUES
(1, 'Ivan', 'Ivanov', 'Owner', NULL),
(2, 'Petar', 'Petrov', 'Manager', NULL),
(3, 'Iva', 'Ivanova', 'Secretary', NULL)

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
(1213, 'Ivan', 'Ivanov', '0887888888', 'T', '0886888888', NULL),
(1214, 'Ivan', 'Petrov', '0887888888', 'T', '0886888888', NULL),
(1215, 'Ivan', 'Georgiev', '0887888888', 'T', '0886888888', NULL)

INSERT INTO RoomStatus VALUES
(0, NULL),
(1, NULL),
(2, NULL)

INSERT INTO RoomTypes VALUES
('Apartment', NULL),
('One Bedroom', NULL),
('President Apartment', NULL)

INSERT INTO BedTypes VALUES
('Single', NULL),
('Double', NULL),
('Luxury', NULL)

INSERT INTO Rooms VALUES
(213, 'One Bedroom', 'Double', NULL, 0, NULL),
(214, 'One Bedroom', 'Double', 7, 1, NULL),
(215, 'One Bedroom', 'Double', NULL, 0, NULL)

INSERT INTO Payments VALUES
(1, 51, '2021-01-13', 151520, '2021-01-13', '2021-01-15', 2, 171.99, 5.01, 5.01, 177, NULL),
(2, 52, '2021-01-13', 151521, '2021-01-13', '2021-01-15', 2, 171.99, 5.01, 5.01, 177, NULL),
(3, 53, '2021-01-13', 151522, '2021-01-13', '2021-01-15', 2, 171.99, 5.01, 5.01, 177, NULL)

USE Hotel

UPDATE Payments
SET TaxRate -= TaxRate * 0.03

SELECT TaxRate FROM Payments

DELETE FROM Occupancies