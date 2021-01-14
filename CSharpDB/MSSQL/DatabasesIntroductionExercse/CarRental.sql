CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories
(
	Id INT IDENTITY PRIMARY KEY,
	CategoryName VARCHAR(30) NOT NULL,
	DailyRate DECIMAL(15,2),
	WeeklyRate DECIMAL(15,2),
	MontlyRate DECIMAL(15,2),
	WeekendRate DECIMAL(15,2)
)

INSERT INTO Categories VALUES
('Sport Car',39.99, 260, 990.99, 67.20),
('Family Car',29.99, 160, 790.99, 57.20),
('Offroad Car',59.99, 360, 1990.99, 97.20)

CREATE TABLE Cars
(
	Id INT IDENTITY PRIMARY KEY,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(20) NOT NULL,
	Model VARCHAR(20) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT NOT NULL,
	Picture VARCHAR(MAX),
	Condition VARCHAR(40) NOT NULL,
	Avaiable BIT NOT NULL
)

ALTER TABLE Cars
ADD FOREIGN KEY (CategoryId) REFERENCES Categories(Id) 

INSERT INTO Cars VALUES
('CA 5555 CB', 'Dacia', 'Duster', 2002, 3, 5, NULL, 'Perfect', 1),
('CA 5225 CB', 'VW', 'Passat', 2012, 2, 5, NULL, 'Perfect', 0),
('CA 9922 CB', 'Porsche', 'Carrera', 2021, 1, 3, NULL, 'Perfect', 1)

CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Title VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees VALUES
('Kevin', 'Philips', 'Manager', NULL),
('Donovan', 'Philips', 'CEO', NULL),
('Ivan', 'Petrov', 'Sales', NULL)

CREATE TABLE Customers
(
	Id INT IDENTITY PRIMARY KEY,
	DriverLicenceNumber VARCHAR(30) NOT NULL,
	FullName VARCHAR(30) NOT NULL,
	[Address] VARCHAR(40) NOT NULL,
	City VARCHAR(20) NOT NULL,
	ZIPCode VARCHAR(8) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES
('02234343', 'Kevin Hart', '5th Avenue', 'New York City', '11-1666', NULL),
('02234342', 'Joe Doe', '5th Avenue', 'New York City', '11-166', NULL),
('02234344', 'John Kennedy', '5th Avenue', 'New York City', '11-1666', NULL)

CREATE TABLE RentalOrders
(
	Id INT IDENTITY PRIMARY KEY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart BIGINT NOT NULL,
	KilometrageEnd BIGINT NOT NULL,
	TotalKilometrage BIGINT NOT NULL,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied INT NOT NULL,
	TaxRate DECIMAL(15,2),
	OrderStatus VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

ALTER TABLE RentalOrders
ADD FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)

ALTER TABLE RentalOrders
ADD FOREIGN KEY (CustomerId) REFERENCES Customers(Id)

ALTER TABLE RentalOrders
ADD FOREIGN KEY (CarId) REFERENCES Cars(Id)

INSERT INTO RentalOrders VALUES
(1,1,1, 34, 72000, 85000, 13000, GETDATE(), GETDATE(), 1, 3, NULL, 'Active', NULL),
(2,2,2, 54, 72000, 85000, 13000, GETDATE(), GETDATE(), 1, 3, NULL, 'Active', NULL),
(3,3,3, 84, 72000, 85000, 13000, GETDATE(), GETDATE(), 1, 3, NULL, 'Closed', NULL)