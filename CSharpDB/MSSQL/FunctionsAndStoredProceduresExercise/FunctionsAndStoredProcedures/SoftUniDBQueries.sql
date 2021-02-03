USE SoftUni

--1.Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
	SELECT 
			FirstName,
			LastName
		FROM Employees
		WHERE Salary > 35000


EXEC usp_GetEmployeesSalaryAbove35000

--2.Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber @Number DECIMAL(18,4)
AS
	SELECT 
			FirstName,
			LastName
		FROM Employees
		WHERE Salary >= @Number


EXEC usp_GetEmployeesSalaryAboveNumber 48100

--3.Town Names Starting With
CREATE OR ALTER PROC usp_GetTownsStartingWith @Symbol VARCHAR(5)
AS
	SELECT [Name]
		FROM Towns
		WHERE [Name] LIKE @Symbol + '%'


EXEC usp_GetTownsStartingWith 'c'

--4.Employees from Town
CREATE PROC usp_GetEmployeesFromTown (@TownName NVARCHAR(60))
AS
	SELECT FirstName, LastName 
		FROM Employees AS e
		JOIN Addresses AS a ON e.AddressID = a.AddressID
		JOIN Towns as t ON a.TownID = t.TownID
		WHERE t.Name = @TownName

EXEC usp_GetEmployeesFromTown 'Berlin'

--5.Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @SalaryLevel NVARCHAR(10)
	IF (@salary < 30000)
		SET @SalaryLevel = 'Low'
	ELSE IF (@salary BETWEEN 30000 AND 50000) 
		SET @SalaryLevel = 'Average'
	ELSE
		SET @SalaryLevel = 'High'

	RETURN @SalaryLevel
END

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary)
	FROM Employees

--6.Employees by Salary Level
CREATE PROC	usp_EmployeesBySalaryLevel  (@SalaryLevel NVARCHAR(10))
AS
	SELECT FirstName, LastName
		FROM Employees
		WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel

EXEC usp_EmployeesBySalaryLevel 'High'

--07. Define Function
CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters VARCHAR(MAX), @Word VARCHAR(MAX))
RETURNS BIT
BEGIN
	DECLARE @Count INT = 1

	WHILE (@Count <= LEN(@Word))
	BEGIN
		DECLARE @CurrentLetter CHAR(1) = SUBSTRING(@Word, @Count, 1)

		IF(CHARINDEX(@CurrentLetter, @SetOfLetters) = 0)
			RETURN 0
		SET @Count += 1
	END
	RETURN 1
END

SELECT dbo.ufn_IsWordComprised ('oistmiahf', 'halves') AS Result

--8.* Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Employees
	SET ManagerID = NULL
	WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

DELETE FROM Employees
WHERE DepartmentID = @departmentId

DELETE FROM Departments
WHERE DepartmentID = @departmentId

SELECT COUNT(*) FROM Employees WHERE DepartmentID = @departmentId

EXEC usp_DeleteEmployeesFromDepartment 1