CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT IDENTITY PRIMARY KEY,
	AddressText VARCHAR(100) NOT NULL,
	TownId INT NOT NULL
)

ALTER TABLE Addresses
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

CREATE TABLE Departments
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(30) NOT NULL,
	MiddleName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	JobTitle VARCHAR(30) NOT NULL,
	DepartmentId INT NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(15,2),
	AdressId INT
)

ALTER TABLE Employees
ADD CONSTRAINT FK_DepartmentId
FOREIGN KEY (DepartmentId) REFERENCES Departments(Id);

ALTER TABLE Employees
ADD CONSTRAINT FK_AdressId
FOREIGN KEY (AdressId) REFERENCES Addresses(Id);


BACKUP DATABASE SoftUni
TO DISK = 'E:\Programs and drivers\softuni\SoftUni.bak'


DROP DATABASE SoftUni

RESTORE DATABASE SoftUni FROM DISK = 'E:\Programs and drivers\softuni\SoftUni.bak' 


INSERT INTO Towns VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013/02/01', 3500.00, NULL),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004/03/02', 4000.00, NULL),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016/08/26', 525.25, NULL),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007/12/09', 3000.00, NULL),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016/08/28', 3599.88, NULL)

SELECT * FROM Towns
ORDER BY [Name] ASC

SELECT * FROM Departments
ORDER BY [Name] ASC

SELECT * FROM Employees
ORDER BY Salary DESC